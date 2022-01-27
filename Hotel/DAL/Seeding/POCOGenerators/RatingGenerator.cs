using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class RatingGenerator
    {
        public async static Task GenerateRatingAsync(this AppDbContext _dbContext)
        {
            await _dbContext.Ratings.AddRangeAsync(
                new Rating { Name=DefaultRatingConstants.Zero},
                new Rating { Name=DefaultRatingConstants.ZeroAndHalf},
                new Rating { Name=DefaultRatingConstants.One},
                new Rating { Name=DefaultRatingConstants.OneAndHalf},
                new Rating { Name=DefaultRatingConstants.Two},
                new Rating { Name=DefaultRatingConstants.TwoAndHalf},
                new Rating { Name=DefaultRatingConstants.Three},
                new Rating { Name=DefaultRatingConstants.ThreeAndHalf},
                new Rating { Name=DefaultRatingConstants.Four},
                new Rating { Name=DefaultRatingConstants.FourAndHalf},
                new Rating { Name=DefaultRatingConstants.Five}
                );
        }
    }
}
