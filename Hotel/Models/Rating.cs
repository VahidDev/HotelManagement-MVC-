using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Rating:Base
    {
        public float Name { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
