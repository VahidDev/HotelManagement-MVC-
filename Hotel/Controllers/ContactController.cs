using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Utilities.ControllerUtilities;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            return View();
        }
    }
}
