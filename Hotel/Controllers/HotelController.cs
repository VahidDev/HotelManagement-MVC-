using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Utilities.ControllerUtilities;
using Hotel.ViewModels.HotelPageViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class HotelController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HotelController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            return View(new HotelIndexViewModel
            {
                HotelPageBannerSection = await _dbContext.HotelPageBannerSections.FirstOrDefaultAsync(),
                Hotels = await _dbContext.Hotels.Where(h => !h.IsDeleted)
                .Include(h=>h.Rating).ToListAsync()
            });
        }
    }
}
