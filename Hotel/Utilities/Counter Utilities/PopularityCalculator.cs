using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;

namespace Hotel.Utilities.Counter_Utilities
{
    public static  class PopularityCalculator
    {
        public static int GetPopularity(float rating)
        {
            if (rating == DefaultRatingConstants.Five) return 25;
            if (rating == DefaultRatingConstants.FourAndHalf) return 20;
            if (rating == DefaultRatingConstants.Four) return 15;
            if (rating == DefaultRatingConstants.ThreeAndHalf) return 10;
            if (rating == DefaultRatingConstants.Three) return 5;
            if (rating == DefaultRatingConstants.Two) return -5;
            if (rating == DefaultRatingConstants.OneAndHalf) return -10;
            if (rating == DefaultRatingConstants.One) return -15;
            if (rating == DefaultRatingConstants.ZeroAndHalf) return -20;
            if (rating == DefaultRatingConstants.Zero) return -25;
            return 0;
        }
    }
}
