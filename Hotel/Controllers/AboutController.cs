using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Utilities.ControllerUtilities;
using Hotel.ViewModels.AboutPageViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AboutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.logo = await LogoAdder.GetLogoAsync(_dbContext);
            return View(new AboutPageIndexViewModel {
            Facilities=await _dbContext.Facilities.Where(f=>!f.IsDeleted).ToListAsync(),
            AboutPageBanner=await _dbContext.AboutPageBannerSections.FirstOrDefaultAsync(),
            AboutPageCeo=await _dbContext.AboutPageCeoSections.FirstOrDefaultAsync()
            });
        }
    }
}
