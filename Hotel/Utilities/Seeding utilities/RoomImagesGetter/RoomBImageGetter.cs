using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;

namespace Hotel.Utilities.Seeding_utilities
{
    public class RoomBImageGetter
    {
        public static ICollection<RoomImage> GetRoomBImages()
        {
            ICollection<RoomImage> roomImages = new List<RoomImage>() {
            new RoomImage(){Name=DefaultRoomImageConstants.RoomBImageMainName,IsMain=true},
            new RoomImage(){Name=DefaultRoomImageConstants.RoomBImage2Name},
            new RoomImage(){Name=DefaultRoomImageConstants.RoomBImage3Name}
            };
            return roomImages;
        }
    }
}
