using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class FacilityGenerator
    {
        public async static Task GenerateFacilityAsync(this AppDbContext _dbContext)
        {
            await _dbContext.Facilities.AddRangeAsync(
                   new Facility { Name = DefaultFacilityConstants.HavalimaniTarnsferi
                      ,Image = DefaultFacilityConstants.HavalimaniTarnsferiImage},
                   new Facility { Name = DefaultFacilityConstants.Yemek
                      ,Image = DefaultFacilityConstants.YemekImage},
                   new Facility { Name = DefaultFacilityConstants.Kondisioner
                      ,Image= DefaultFacilityConstants.KondisionerImage},
                   new Facility { Name = DefaultFacilityConstants.Tehlukesizlik
                      ,Image= DefaultFacilityConstants.TehlukesizlikImage},
                   new Facility { Name = DefaultFacilityConstants.QapaliHovuz
                      ,Image= DefaultFacilityConstants.QapaliHovuzImage},
                   new Facility { Name = DefaultFacilityConstants.WiFi
                      ,Image= DefaultFacilityConstants.WiFiImage},
                   new Facility { Name = DefaultFacilityConstants.SmartTV
                      ,Image= DefaultFacilityConstants.SmartTVImage},
                   new Facility { Name = DefaultFacilityConstants.Chamashırxana
                      ,Image= DefaultFacilityConstants.ChamashırxanaImage}
                   );
        }
    }
}
