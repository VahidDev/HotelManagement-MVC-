using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Reservation:Base
    {
        public User User { get; set; }
        public Room Room { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public DateTime EndDate { get; set; }
    }
}
