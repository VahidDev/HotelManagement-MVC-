using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities;
using Hotel.Utilities.Counter_Utilities;
using Hotel.ViewModels.RoomSectionViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class RoomController:Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RoomController(AppDbContext dbContext, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            return View(await _dbContext.Rooms.Include(r=>r.Hotel)
                .Include(r=>r.RoomImages.Where(i=>i.IsMain))
                .Where(r=>!r.IsDeleted).ToListAsync());
        }
        public async Task<IActionResult> GetRoomsByHotel(int id)
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            return View(new RoomGetRoomsByHotelViewModel
            {
                Hotel = await _dbContext.Hotels.FindAsync(id),
                Rooms = await _dbContext.Rooms.Where(r => !r.IsDeleted && r.Hotel.Id == id)
                .Include(r => r.RoomImages.Where(i => i.IsMain)).ToListAsync()
            });
        }
        public async Task<IActionResult> Reservation(int id)
        {
            Room room = await _dbContext.Rooms.Include(r=>r.Hotel)
                .Include(r => r.Facilities.Where(f => !f.IsDeleted))
                .FirstOrDefaultAsync(r=>r.Id==id);
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            return View(new RoomReservationViewModel
            {
             Room=room,
             Facilities=room.Facilities,
             Comments=await _dbContext.Comments
             .Where(c=>!c.IsDeleted &&c.Room.Id==id)
             .Include(c => c.Rating).ToListAsync(),
             Images=await _dbContext.RoomImages
             .Where(i=>!i.IsDeleted&&i.Room.Id==id&&!i.IsMain).ToListAsync(),
             MainImage= await _dbContext.RoomImages
             .FirstOrDefaultAsync(i=>!i.IsDeleted&&i.Room.Id==id&&i.IsMain),
             Ratings=await _dbContext.Ratings.Where(r=>!r.IsDeleted).ToListAsync()
            });
        }
        [HttpPost]
        public async Task<JsonResult> Comment(string name,string content,string email
            ,int roomId,int ratingId)
        {
            Room room = await _dbContext.Rooms.Include(r=>r.Hotel).FirstOrDefaultAsync(r=>r.Id==roomId);
            if (string.IsNullOrEmpty(name) 
                || string.IsNullOrEmpty(content) || string.IsNullOrEmpty(email))
            {
                return null;
            }else if (room == null)
            {
                return null;
            }
            Rating rating =await _dbContext.Ratings.FindAsync(ratingId);
            if (rating == null)
            {
                rating = await _dbContext.Ratings
                    .FirstOrDefaultAsync(r => r.Name == DefaultRatingConstants.Five);
            }
            Comment comment = new()
            {
                Content = content,
                FullName = name,
                Room = room,
                Rating=rating,
            };
            User user = _userManager.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                comment.User = user;
            }
            // Add popularity to the room and hotel
            int popularity= PopularityCalculator.GetPopularity(rating.Name);
            room.Popularity += popularity;
            room.Hotel.Popularity+= popularity;
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return Json(comment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservation(RoomReservationViewModel model)
        {
            Room room = await _dbContext.Rooms.Include(r=>r.Hotel)
                .Include(r=>r.Facilities).Include(r=>r.RoomImages).Include(r=>r.Reservations)
                .FirstOrDefaultAsync(r=>r.Id==model.RoomId);
            if (room == null) return BadRequest();
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            model.Room = room;
            model.MainImage = room.RoomImages.FirstOrDefault(i => i.IsMain);
            model.Images = room.RoomImages.Where(i => !i.IsMain).ToList();
            model.Facilities = room.Facilities;
            model.Comments = await _dbContext.Comments.Where(c =>c.Room==room&& !c.IsDeleted)
                .Include(c=>c.Rating).ToListAsync();
            model.Ratings = await _dbContext.Ratings.Where(r=>!r.IsDeleted).ToListAsync();
            if (!ModelState.IsValid) return View(model);
            if (!User.Identity.IsAuthenticated)
            {
                ModelState.AddModelError(nameof(RoomReservationViewModel.AdultCount),
                    "First you need to login");
                return View(model);
            }
            if (!DateChecker.IsValid(model.StartDate, model.EndDate))
            {
                ModelState.AddModelError(nameof(RoomReservationViewModel.EndDate), "Invalid dates");
                return View(model);
            }
            if (DateChecker.IsConflicted(room,model.StartDate,model.EndDate))
            {
                ModelState.AddModelError(nameof(RoomReservationViewModel.EndDate),
                    "The chosen range conflicts with one of the reservations in the database");
                return View(model);
            }
            if (model.AdultCount + model.ChildCount > room.Type)
            {
                ModelState.AddModelError(nameof(RoomReservationViewModel.AdultCount),
                    "Too many people for this room");
                return View(model);
            }
            await _dbContext.Reservations.AddAsync(new Reservation {
            User=await _userManager.GetUserAsync(HttpContext.User),
            StartDate=model.StartDate,
            EndDate=model.EndDate,
            AdultCount=model.AdultCount,
            ChildCount=model.ChildCount,
            Room=room
            });
            room.Popularity += 50;
            room.Hotel.Popularity += 50;
            room.ReservationCount += 1;
            room.Hotel.ReservationCount += 1;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(HotelController.Index), "Hotel");
        }
    }
}
