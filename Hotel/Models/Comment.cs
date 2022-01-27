using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Comment:Base
    {
        public string Content { get; set; }
        public Rating Rating { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public string FullName { get; set; }
    }
}
