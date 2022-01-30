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
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Index()
        {
            return View(new AdminHotelIndexViewModel
            {
                Hotels = await _dbContext.Hotels.Where(h => !h.IsDeleted)
                .Include(h => h.User).Include(h=>h.Rating).ToListAsync()
            });
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
            Models.Hotel hotel = await CreateHotelMapper.MapAsync(model, guid, _dbContext, user);
            user.IsHotelUser = true;
            await _dbContext.Hotels.AddAsync(hotel);
            await _userManager.AddToRoleAsync(user, DefaultRoleConstants.Hotel);
            await _userManager.UpdateAsync(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public async Task<string> Delete(int id)
        {
            Models.Hotel hotel = await _dbContext.Hotels.Include(h=>h.Rooms).Include(h=>h.User)
                .FirstOrDefaultAsync(h=> h.Id == id && !h.IsDeleted);
            if (hotel == null) return "Not Found";
            if (hotel.Rooms.Count!=0)
            {
                return "Hotel Error";
            }
            hotel.IsDeleted = true;
            hotel.DeletedDate = DateTime.Now;
            FileDeleter.Delete(FileNameConstants.HotelImage, hotel.Image);
            // Find The user of this hotel and set IsHotelUser to false and remove role
            User user = await _userManager.Users.FirstOrDefaultAsync
              (u => !u.IsDeleted && u.IsHotelUser && u.Id == hotel.User.Id);
            user.IsHotelUser = false;
            FileDeleter.Delete(FileNameConstants.HotelImage, hotel.Image);
            await _userManager.RemoveFromRoleAsync(user, DefaultRoleConstants.Hotel);
            await _userManager.UpdateAsync(user);
             _dbContext.Hotels.Update(hotel);
            await _dbContext.SaveChangesAsync();
            return "Success";
        }
     
        public async Task<IActionResult>Update(int id)
        {
            Models.Hotel hotel = await _dbContext.Hotels.Include(h => h.User).Include(h => h.Rating)
               .FirstOrDefaultAsync(h => h.Id == id && !h.IsDeleted);
            if (hotel == null) return NotFound();
            AdminHotelUpdateViewModel model = await UpdateHotelMapper.MapAsync(_dbContext, id,hotel);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdminHotelUpdateViewModel model,int id)
        {
            Models.Hotel hotel = await _dbContext.Hotels.Include(h=>h.Rating)
                .FirstOrDefaultAsync(h => !h.IsDeleted && model.HotelId==h.Id);
            if (hotel == null) return NotFound();
            if (hotel.Id != id) return BadRequest();
            model.ImageName = hotel.Image;
            model.HotelId = hotel.Id;
            model.Rating=await _dbContext.Ratings.FirstOrDefaultAsync(r=>r.Id==model.RatingId&&!r.IsDeleted);
            if (model.Rating == null) return BadRequest();
            if (model.HotelId != id) return BadRequest();
            HotelMapper.MapHotel(model, hotel);
            if (!ModelState.IsValid) return View(model);
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.CheckSizeForMg())
                {
                    ModelState.AddModelError(nameof(AdminHotelUpdateViewModel.ImageFile),
                        FileMessageConstants.MgSizeError);
                    return View(model);
                }
                if (!model.ImageFile.CheckContentForImg())
                {
                    ModelState.AddModelError(nameof(AdminHotelUpdateViewModel.ImageFile),
                        FileMessageConstants.MgSizeError);
                    return View(model);
                }
                Guid guid = Guid.NewGuid();
                FileDeleter.Delete(FileNameConstants.HotelImage, hotel.Image);
                await model.ImageFile.CreateAsync(guid, FileNameConstants.HotelImage);
                hotel.Image = guid + model.ImageFile.FileName;
            }
            _dbContext.Hotels.Update(hotel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Detail(int id)
        {
            Models.Hotel hotel = await _dbContext.Hotels
                .Include(h => h.Rating).Include(h=>h.User).Include(h=>h.Rooms)
               .FirstOrDefaultAsync(h => !h.IsDeleted && id == h.Id);
            if (hotel == null) return NotFound();
            AdminHotelDetailViewModel model = new()
            {
                Hotel = hotel,
            };
            ICollection<Room> rooms = await _dbContext.Rooms.Where(r => r.Hotel == hotel && !r.IsDeleted)
                .Include(r => r.RoomImages.Where(i => i.IsMain)).ToListAsync();
            foreach (Room room in rooms)
            {
                model.RoomAndImages.Add(new RoomAndImage { 
                Room=room,
                Image=room.RoomImages.FirstOrDefault()
                });
            }
            return View(model);
        }
       
    }
}
