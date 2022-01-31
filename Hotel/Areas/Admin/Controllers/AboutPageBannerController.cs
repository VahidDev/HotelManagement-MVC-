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
    public class AboutPageBannerController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AboutPageBannerController(AppDbContext dbContext, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.AboutPageBannerSections.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Update()
        {
            AboutPageBannerSection banner = await _dbContext.AboutPageBannerSections.FirstOrDefaultAsync();
            return View(new AboutPageBannerUpdateViewModel{
            Image=banner.Image,
            Title=banner.Title,
            Description=banner.Description
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutPageBannerUpdateViewModel model)
        {
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.CheckSizeForMg())
                {
                    ModelState.AddModelError(nameof(AboutPageBannerUpdateViewModel.ImageFile),
                        FileMessageConstants.MgSizeError);
                }
                if (!model.ImageFile.CheckContentForImg())
                {
                    ModelState.AddModelError(nameof(AboutPageBannerUpdateViewModel.ImageFile),
                        FileMessageConstants.ImageContentError);
                }
                FileDeleter.Delete(FileNameConstants.AboutBannerImage, model.Image);
                Guid guid = Guid.NewGuid();
                await model.ImageFile.CreateAsync(guid, FileNameConstants.AboutBannerImage);
                model.Image = guid + model.ImageFile.FileName;
            }
            if (!ModelState.IsValid) return View(model);
            AboutPageBannerSection banner = await _dbContext.AboutPageBannerSections.FirstOrDefaultAsync();
            banner.Image = model.Image;
            banner.Title = model.Title;
            banner.Description = model.Description;
            _dbContext.AboutPageBannerSections.Update(banner);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
