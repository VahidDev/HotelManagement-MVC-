using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.UserUtilities;
using Microsoft.AspNetCore.Identity;

namespace Hotel.ViewModels.AdminViewModels.UserViewModels
{
    public class UserIndexViewModel
    {
        public ICollection<UserAndRole> UsersRoles { get; set; } = new List<UserAndRole>();
    }
}
