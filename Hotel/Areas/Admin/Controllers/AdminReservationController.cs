using System;
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
    [Authorize(Roles = nameof(DefaultRoleConstants.Admin))]
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
        [HttpPost]
        public async Task<string> Delete(int id)
        {
            Reservation reservation = await _dbContext.Reservations
                .FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (reservation == null) return "Not Found";
            reservation.IsDeleted = true;
            reservation.DeletedDate = DateTime.Now;
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
