using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.UserUtilities;
using Hotel.ViewModels.AdminViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(DefaultRoleConstants.Admin))]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(AppDbContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
           string currentUserId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            IdentityRole adminRole = await _roleManager.FindByNameAsync(DefaultRoleConstants.Admin);
            // we need this to exclude admin user because we won't show admin user in the user list
            IdentityUserRole<string> adminAndRole = await _dbContext.UserRoles
             .Where(ur => ur.RoleId == adminRole.Id).FirstOrDefaultAsync();
            ICollection<User> users = await _userManager.Users
          .Where(u => !u.IsDeleted && u.Id != adminAndRole.UserId && u.Id != currentUserId)
          .ToListAsync();
            UserIndexViewModel model = new UserIndexViewModel();
            foreach (User user in users)
            {
                model.UsersRoles.Add(new UserAndRole { 
                User=user,
                RolesNames=await _userManager.GetRolesAsync(user),
                });
            }
            return View(model);
        }
        public async Task<JsonResult> Search(string userName)
        {
            UserIndexViewModel model = new();
            if (String.IsNullOrEmpty(userName))
            {
                ICollection<User> Allusers = await _userManager.Users.Where(u => !u.IsDeleted).ToListAsync();
                foreach (User user in Allusers)
                {
                    model.UsersRoles.Add(new UserAndRole
                    {
                        User = user,
                        RolesNames = await _userManager.GetRolesAsync(user),
                    });
                }
                return Json(model);
            }
            ICollection<User> users = await _userManager.Users.Where
                (u => !u.IsDeleted&&u.UserName.StartsWith(userName)).ToListAsync();
            foreach (User user in users)
            {
                model.UsersRoles.Add(new UserAndRole
                {
                    User = user,
                    RolesNames = await _userManager.GetRolesAsync(user),
                });
            }
            return Json(model);
        }
        public async Task<IActionResult>Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(UserCreateViewModel model)
        {
            if (!ModelState.IsValid) return View();
            if (_dbContext.Users.Any(u => !u.IsDeleted && u.Email == model.Email))
            {
                ModelState.AddModelError(nameof(UserCreateViewModel.Email),
                     "Bu email-nan artiq bashqa bir istifadeci databazada var. " +
                    "Xaish edirik bashqa email daxil edin");
                return View();
            }
            User user = new()
            {
                Email = model.Email,
                UserName = model.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, DefaultRoleConstants.User);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(string id)
        {
            User user = await _userManager.Users.Include(u => u.Comments)
            .ThenInclude(c=>c.Room).ThenInclude(r => r.Hotel).Include(u=>u.Comments)
            .ThenInclude(c=>c.Rating).FirstOrDefaultAsync(u => u.Id == id &&!u.IsDeleted);
            if (user == null) return NotFound();
            return View(new UserDetailViewModel { 
            User= user,
            Reservations=await _dbContext.Reservations.Include(r=>r.Room).ThenInclude(r=>r.Hotel)
            .Where(r=>!r.IsDeleted&&r.User==user).ToListAsync(),
            });
        }
        public async Task<IActionResult> Update(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u=>u.Id==id&&!u.IsDeleted);
            if (user == null) return NotFound();
            return View(new UserUpdateViewModel
            {
                Id=user.Id,
                UserName=user.UserName,
                Email=user.Email,
            });
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult>Update (UserUpdateViewModel model)
        {
            User user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == model.Id && !u.IsDeleted);
            if (user == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            if (_userManager.Users.Any(u => u.Email == model.Email && u.Id != user.Id))
            {
                ModelState.AddModelError(nameof(UserUpdateViewModel.Email),
                    "Bu email-nan artiq bashqa bir istifadeci databazada var. " +
                    "Xaish edirik bashqa email daxil edin");
                return View(model);
            }
            UserUpdateMapper.MapUser(user, model);
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<string> Delete(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u=>u.Id==id&&!u.IsDeleted);
            if (user == null) return "Not Found";
            if (user.IsHotelUser)
            {
                Models.Hotel hotel = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.User == user);
                if (!hotel.IsDeleted)
                {
                    return "Hotel Error";
                }
            }
            user.IsDeleted = true;
            user.DeletedDate = DateTime.Now;
            await _userManager.UpdateAsync(user);
            await _dbContext.SaveChangesAsync();
            return "Success";
        }
        public async Task<bool> Block(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u=>!u.IsDeleted&& u.Id==id);
            if (user == null) return false;
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTimeOffset.MaxValue;
            user.IsBlocked = true;
            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UnBlock(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == id);
            if (user == null) return false;
            user.LockoutEnd = DateTimeOffset.Now;
            user.IsBlocked = false;
            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
