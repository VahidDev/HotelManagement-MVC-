using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Utilities.ControllerUtilities.UserUtilities
{
    public class UserAndRole
    {
        public User User { get; set; }
        public ICollection<string> RolesNames { get; set; }
    }
}
