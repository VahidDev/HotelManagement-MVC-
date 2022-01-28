using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Hotel.ViewModels.AdminViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Constants.POCOConstants.DefaultRoleConstants.Admin) + ","
       + nameof(Constants.POCOConstants.DefaultRoleConstants.Hotel))]
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
            return View(await _userManager.Users.Where(u=>!u.IsDeleted).ToListAsync());
        }
        public async Task<IActionResult> Detail(string id)
        {
            User user = await _userManager.Users.Include(u => u.Comments)
                .ThenInclude(c=>c.Room).ThenInclude(r => r.Hotel)
           .Include(u=>u.Comments).ThenInclude(c=>c.Rating).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound();
            return View(new UserDetailViewModel { 
            User= user,
            Reservation=await _dbContext.Reservations.Include(r=>r.Room).ThenInclude(r=>r.Hotel)
            .Where(r=>!r.IsDeleted&&r.User==user).FirstOrDefaultAsync()
            });
        }
    }
}
