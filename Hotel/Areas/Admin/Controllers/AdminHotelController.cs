using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants;
using Hotel.Constants.MessageConstants;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;
using Hotel.Utilities.FileUtilities;
using Hotel.ViewModels.AdminViewModels.AdminHotelViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =nameof(DefaultRoleConstants.Admin))]
    public class AdminHotelController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminHotelController(AppDbContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> CreateHotel(string id)
        {
            User user = await _userManager.Users
                .FirstOrDefaultAsync(u =>!u.IsDeleted&&!u.IsHotelUser&& u.Id == id);
            if (user == null) return NotFound();
            return View(new AdminHotelCreateViewModel
            {
                UserId = id,
                Ratings=await _dbContext.Ratings.Where(r=>!r.IsDeleted).ToListAsync()
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHotel(AdminHotelCreateViewModel model,string id)
        {
            User user = await _userManager.Users
                .FirstOrDefaultAsync(u => !u.IsDeleted &&!u.IsHotelUser && u.Id == id);
            if (user == null) return NotFound();
            if (model.UserId != id) return BadRequest();
            model.Ratings = await _dbContext.Ratings.Where(r => !r.IsDeleted).ToListAsync();
            if (model.RatingId == 0)
            {
                ModelState.AddModelError(nameof(AdminHotelCreateViewModel.RatingId),
                    "Rating secilmelidir!");
            }
            if (!ModelState.IsValid) return View(model);
            if (!model.ImageFile.CheckSizeForMg())
            {
                ModelState.AddModelError(nameof(AdminHotelCreateViewModel.ImageFile),
                    FileMessageConstants.MgSizeError);
                return View(model);
            }
            if (!model.ImageFile.CheckContentForImg())
            {
                ModelState.AddModelError(nameof(AdminHotelCreateViewModel.ImageFile),
                    FileMessageConstants.ImageContentError);
                return View(model);
            }
            Guid guid = Guid.NewGuid();
            await model.ImageFile.CreateAsync(guid,FileNameConstants.HotelImage);
            Models.Hotel hotel = await HotelMapper.MapAsync(model, guid, _dbContext, user);
            user.IsHotelUser = true;
            await _dbContext.Hotels.AddAsync(hotel);
            await _userManager.AddToRoleAsync(user, DefaultRoleConstants.Hotel);
            await _userManager.UpdateAsync(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
