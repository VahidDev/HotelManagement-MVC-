using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Utilities.ControllerUtilities;
using Hotel.Utilities.ControllerUtilities.HomeUtilities;
using Hotel.ViewModels.HomePageViewModels;
using Hotel.ViewModels.ReservationControllerViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            return View(await HomeControllerMapper.MapHomeIndexViewModelAsync(_dbContext));
        }

        public async Task<IActionResult> Reservation(HomeIndexViewModel model)
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            HomeIndexViewModel reservationModel = await HomeReservationMapper
                .MapHomeReservationModelAsync(model, _dbContext);
            if (!ModelState.IsValid) return View(nameof(Index),reservationModel);
            if (!DateChecker.IsValid(reservationModel.ReservationStart, 
                reservationModel.ReservationEnd))
            {
                ModelState.AddModelError(nameof(HomeIndexViewModel.ReservationEnd),
                    "Invalid dates");
                return View(nameof(Index),reservationModel);
            }
            TempData["reservationModel"] =JsonConvert.SerializeObject(new ReservationViewModel
            {
                StartDate=reservationModel.ReservationStart,
                EndDate=reservationModel.ReservationEnd,
                AdultCount=reservationModel.AdultCount,
                ChildCount=reservationModel.ChildCount
            });
            return RedirectToAction(nameof(ReservationController.Index),"Reservation");
        }
    }
}
