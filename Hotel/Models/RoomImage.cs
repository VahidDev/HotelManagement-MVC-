using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class RoomImage:Base
    {
        public string Name { get; set; }
        public Room Room { get; set; }
        public bool IsMain { get; set; }
    }
}
