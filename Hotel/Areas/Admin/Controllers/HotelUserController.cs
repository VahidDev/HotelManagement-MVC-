using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;
using Hotel.ViewModels.AdminViewModels.AdminHotelViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Constants.POCOConstants.DefaultRoleConstants.Admin) + ","
     + nameof(Constants.POCOConstants.DefaultRoleConstants.Hotel))]
    public class HotelUserController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HotelUserController(AppDbContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Models.Hotel hotel = await _dbContext.Hotels
                .Include(h => h.Rating).Include(h => h.User).Include(h => h.Rooms)
               .FirstOrDefaultAsync(h => !h.IsDeleted &&user== h.User);
            if (hotel == null) return NotFound();
            AdminHotelDetailViewModel model = new()
            {
                Hotel = hotel,
            };
            ICollection<Room> rooms = await _dbContext.Rooms.Where(r => r.Hotel == hotel && !r.IsDeleted)
                .Include(r => r.RoomImages.Where(i => i.IsMain)).ToListAsync();
            foreach (Room room in rooms)
            {
                model.RoomAndImages.Add(new RoomAndImage
                {
                    Room = room,
                    Image = room.RoomImages.FirstOrDefault()
                });
            }   
            return View(model);
        }
        public async Task<IActionResult> CreateRoom()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Models.Hotel hotel = await _dbContext.Hotels
                .Include(h => h.Rating).Include(h => h.User).Include(h => h.Rooms)
               .FirstOrDefaultAsync(h => !h.IsDeleted && user == h.User);
            if (hotel == null) return NotFound();
            return RedirectToAction(nameof(AdminRoomController.Create),"AdminRoom",new { hotel.Id});
        }
        public async Task<IActionResult> GetRooms()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Models.Hotel hotel = await _dbContext.Hotels
                .Include(h => h.Rating).Include(h => h.User).Include(h => h.Rooms)
               .FirstOrDefaultAsync(h => !h.IsDeleted && user == h.User);
            if (hotel == null) return NotFound();
            AdminHotelDetailViewModel model = new()
            {
                Hotel = hotel,
            };
            ICollection<Room> rooms = await _dbContext.Rooms.Where(r => r.Hotel == hotel && !r.IsDeleted)
                .Include(r => r.RoomImages.Where(i => i.IsMain)).ToListAsync();
            foreach (Room room in rooms)
            {
                model.RoomAndImages.Add(new RoomAndImage
                {
                    Room = room,
                    Image = room.RoomImages.FirstOrDefault()
                });
            }
            return View(model);
        }
    }
}
