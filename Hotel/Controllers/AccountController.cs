using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models;
using Hotel.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginRegisterViewModel accModel)
        {
            AccountLoginViewModel model = accModel.AccountLoginViewModel;
            if (!ModelState.IsValid) return View();
            User user =await  _userManager.Users.FirstOrDefaultAsync(u=>u.UserName==model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("","Bele bir istifadechi databazada yoxdur");
                return View();
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountLoginRegisterViewModel accModel)
        {
            AccountRegisterViewModel model = accModel.AccountRegisterViewModel;
            if(!ModelState.IsValid) return View(nameof(AccountController.Login));
            User user = new()
            {
                Email = model.Email,
                UserName = model.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("",error.ToString());
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, DefaultRoleConstants.User);
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
    }
}
