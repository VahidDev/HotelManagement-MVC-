using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities;
using Hotel.Utilities.ControllerUtilities.ReservationUtilities;
using Hotel.ViewModels.HomePageViewModels;
using Hotel.ViewModels.ReservationControllerViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ReservationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            ReservationViewModel model = JsonConvert.DeserializeObject<ReservationViewModel>
                (TempData["reservationModel"] as string);
            model.Rooms= await AvailableRoomsGetter
                .GetAvailableRoomsAsync(_dbContext, model.StartDate,
                model.EndDate,model.AdultCount+model.ChildCount);
            return View(model);
        }
    }
}
