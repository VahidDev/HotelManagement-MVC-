using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.ViewModels.AdminViewModels.UserViewModels;

namespace Hotel.Utilities.ControllerUtilities.UserUtilities
{
    public static class UserUpdateMapper
    {
        public static void MapUser(User user,UserUpdateViewModel model)
        {
            user.Email = model.Email;
            user.UserName = model.UserName;
        }
    }
}
