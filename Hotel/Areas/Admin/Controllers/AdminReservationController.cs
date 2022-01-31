using System;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities;
using Hotel.ViewModels.AdminViewModels.AdminReservationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(DefaultRoleConstants.Admin) + ","
    + nameof(DefaultRoleConstants.Hotel))]
    public class AdminReservationController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminReservationController(AppDbContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> MakeReservation(int id)
        {
            Room room= await _dbContext.Rooms.Include(r => r.Hotel)
                .Include(r=>r.Reservations.Where(r=>!r.IsDeleted))
                 .FirstOrDefaultAsync(r => !r.IsDeleted && r.Id == id);
            if (room == null) return NotFound();
            return View(new ReservationCreateViewModel
            {
                HotelId=room.Hotel.Id,
                RoomId=room.Id,
                RoomName=room.Name,
                HotelName=room.Hotel.Name,
                MaxPeopleCount=room.Type
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeReservation(ReservationCreateViewModel model,int id)
        {
            Room room = await _dbContext.Rooms.Include(r => r.Hotel)
                .Include(r => r.Reservations.Where(r => !r.IsDeleted))
                 .FirstOrDefaultAsync(r => !r.IsDeleted && r.Id == id);
            if (room == null) return NotFound();
            if (model.HotelId != room.Hotel.Id) return BadRequest();
            if (model.RoomId != room.Id) return BadRequest();
            if (!DateChecker.IsValid(model.StartDate, model.EndDate))
            {
                ModelState.AddModelError(nameof(ReservationCreateViewModel.EndDate),
                    "Invalid Dates");
            }
            if (DateChecker.IsConflicted(room, model.StartDate, model.EndDate))
            {
                ModelState.AddModelError(nameof(ReservationCreateViewModel.EndDate),
                    "These dates conflict with one of the reservations for this room");
            }
            if (model.AdultCount + model.ChildCount > room.Type)
            {
                ModelState.AddModelError(nameof(ReservationCreateViewModel.AdultCount),
                    "Bu otaq ucun adam sayi coxdur");
            }
            if (model.AdultCount == 0)
            {
                ModelState.AddModelError(nameof(ReservationCreateViewModel.AdultCount),
                    "En azi 1 nefer vaxt daxil olunmalidir!");
            }
            if (!ModelState.IsValid) return View(model);
            room.ReservationCount++;
            room.Hotel.ReservationCount++;
            room.Popularity += 50;
            room.Hotel.Popularity += 50;
            _dbContext.Rooms.Update(room);
            _dbContext.Hotels.Update(room.Hotel);
            await _dbContext.Reservations.AddAsync(new Reservation {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                AdultCount = model.AdultCount,
                ChildCount = model.ChildCount,
                Room=room,
                User=await _userManager.GetUserAsync(HttpContext.User)
            });
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(AdminRoomController.Detail), "AdminRoom"
                , new {id});
        }
        [HttpPost]
        public async Task<string> Delete(int id)
        {
            Reservation reservation = await _dbContext.Reservations.Include(r=>r.Room).ThenInclude(r=>r.Hotel)
                .FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (reservation == null) return "Not Found";
            reservation.IsDeleted = true;
            reservation.DeletedDate = DateTime.Now;
            reservation.Room.ReservationCount--;
            reservation.Room.Hotel.ReservationCount--;
            reservation.Room.Popularity -= 30;
            reservation.Room.Hotel.Popularity -= 30;
            _dbContext.Reservations.Update(reservation);
            _dbContext.Rooms.Update(reservation.Room);
            _dbContext.Hotels.Update(reservation.Room.Hotel);
            await _dbContext.SaveChangesAsync();
            return "Success";
        }
        public async Task<IActionResult>Update(int id)
        {
            Reservation reservation = await _dbContext.Reservations
                .Include(r=>r.User).Include(r=>r.Room).ThenInclude(r=>r.Hotel)
                .FirstOrDefaultAsync(r => !r.IsDeleted&&r.Id==id);
            if (reservation == null) return NotFound();
            return View(new ReservationUpdateViewModel {
            StartDate=reservation.StartDate,
            EndDate=reservation.EndDate,
            AdultCount=reservation.AdultCount,
            ChildCount=reservation.ChildCount,
            ReservationId=reservation.Id,
            UserName=reservation.User.UserName,
            HotelId=reservation.Room.Hotel.Id,
            HotelName=reservation.Room.Hotel.Name,
            RoomId=reservation.Room.Id,
            RoomName= reservation.Room.Name,
            MaxPeopleCount=reservation.Room.Type
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ReservationUpdateViewModel model,int id)
        {
            Reservation reservation = await _dbContext.Reservations
                .Include(r => r.User).Include(r => r.Room).ThenInclude(r => r.Hotel)
                .FirstOrDefaultAsync(r => !r.IsDeleted &&r.Id==id);
            if (reservation == null) return NotFound();
            if (model.ReservationId != id) return BadRequest();
            if (model.HotelId != reservation.Room.Hotel.Id) return BadRequest();
            if (model.RoomId!=reservation.Room.Id) return BadRequest();
            if (!DateChecker.IsValid(model.StartDate, model.EndDate))
            {
                ModelState.AddModelError(nameof(ReservationUpdateViewModel.EndDate),
                    "Invalid Dates");
            }
            if (DateChecker.IsConflicted(reservation.Room,model.StartDate, model.EndDate))
            {
                ModelState.AddModelError(nameof(ReservationUpdateViewModel.EndDate),
                    "These dates conflict with one of the reservations for this room");
            }
            if (model.AdultCount+model.ChildCount>reservation.Room.Type)
            {
                ModelState.AddModelError(nameof(ReservationUpdateViewModel.AdultCount),
                    "Bu otaq ucun adam sayi coxdur");
            }
            if (!ModelState.IsValid) return View(model);
            reservation.StartDate = model.StartDate;
            reservation.EndDate = model.EndDate;
            reservation.AdultCount = model.AdultCount;
            reservation.ChildCount = model.ChildCount;
            _dbContext.Reservations.Update(reservation);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(AdminRoomController.Detail),"AdminRoom"
                ,new {id=reservation.Room.Id });
        }
    }
}
