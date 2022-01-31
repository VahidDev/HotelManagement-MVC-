using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Utilities.ControllerUtilities;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ServiceController(AppDbContext dbContext)
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
