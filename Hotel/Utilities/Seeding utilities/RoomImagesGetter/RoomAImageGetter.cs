using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;

namespace Hotel.Utilities.Seeding_utilities
{
    public class RoomAImageGetter
    {
        public static ICollection<RoomImage> GetRoomAImages()
        {
            ICollection<RoomImage> roomImages = new List<RoomImage>() { 
            new RoomImage(){Name=DefaultRoomImageConstants.RoomAImageMainName,IsMain=true},
            new RoomImage(){Name=DefaultRoomImageConstants.RoomAImage2Name},
            new RoomImage(){Name=DefaultRoomImageConstants.RoomAImage3Name},
            new RoomImage(){Name=DefaultRoomImageConstants.RoomAImage4Name},
            };
            return roomImages;
        }
    }
}
