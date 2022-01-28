using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.ViewModels.AdminViewModels.UserViewModels
{
    public class UserIndexViewModel
    {
        public ICollection<User> Users { get; set; }
        public string AdminUserId { get; set; }
        public string CurrentUserId { get; set; }
    }
}
