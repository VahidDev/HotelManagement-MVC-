using System;
using System.Threading.Tasks;
using Hotel.Constants;
using Hotel.Constants.MessageConstants;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Models.WebsiteSections.AboutPageSections;
using Hotel.Utilities.FileUtilities;
using Hotel.ViewModels.AdminViewModels.AboutPageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(DefaultRoleConstants.Admin))]
    public class AboutPageCeoController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AboutPageCeoController(AppDbContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.AboutPageCeoSections.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Update()
        {
            AboutPageCeoSection banner = await _dbContext.AboutPageCeoSections.FirstOrDefaultAsync();
            return View(new AboutPageCeoUpdateViewModel
            {
                Image = banner.CeoImage,
                CeoName = banner.CeoName,
                Description = banner.Description
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutPageCeoUpdateViewModel model)
        {
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.CheckSizeForMg())
                {
                    ModelState.AddModelError(nameof(AboutPageCeoUpdateViewModel.ImageFile),
                        FileMessageConstants.MgSizeError);
                }
                if (!model.ImageFile.CheckContentForImg())
                {
                    ModelState.AddModelError(nameof(AboutPageCeoUpdateViewModel.ImageFile),
                        FileMessageConstants.ImageContentError);
                }
                FileDeleter.Delete(FileNameConstants.AboutCeoImage, model.Image);
                Guid guid = Guid.NewGuid();
                await model.ImageFile.CreateAsync(guid, FileNameConstants.AboutCeoImage);
                model.Image = guid + model.ImageFile.FileName;
            }
            if (!ModelState.IsValid) return View(model);
            AboutPageCeoSection ceo = await _dbContext.AboutPageCeoSections.FirstOrDefaultAsync();
            ceo.CeoImage = model.Image;
            ceo.CeoName = model.CeoName;
            ceo.Description = model.Description;
            _dbContext.AboutPageCeoSections.Update(ceo);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
