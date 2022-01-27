using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Facility:Base
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
