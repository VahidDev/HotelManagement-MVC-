using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =nameof(Constants.POCOConstants.DefaultRoleConstants.Admin)+","
        +nameof(Constants.POCOConstants.DefaultRoleConstants.Hotel))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
