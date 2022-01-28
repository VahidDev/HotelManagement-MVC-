using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.ViewModels.AdminViewModels.UserViewModels
{
    public class UserDetailViewModel
    {
        public Reservation Reservation{ get; set; }
        public User User { get; set; }
    }
}
