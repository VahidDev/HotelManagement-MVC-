using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL.Seeding.POCOGenerators;
using Hotel.DAL.Seeding.POCOGenerators.WebsiteSectionGenerators;
using Hotel.DAL.Seeding.POCOGenerators.WebsiteSectionGenerators.AboutPageGenerators;
using Hotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DAL.Seeding
{
    public class DatabaseSeeder
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DatabaseSeeder(AppDbContext dbContext,UserManager<User> userManager
            ,RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            _dbContext.Database.Migrate();
            if (!_dbContext.Facilities.Any())
                await _dbContext.GenerateFacilityAsync();
            if (!_dbContext.Ratings.Any())
                await _dbContext.GenerateRatingAsync();
            if (!_dbContext.Roles.Any())
                await _roleManager.GenerateDefaultRolesAsync();
            if (!_dbContext.Users.Any())
                await _userManager.GenerateDefaultUsersAsnyc();
            if (!_dbContext.Hotels.Any())
                await _dbContext.GenerateHotelAsync(_userManager);
            if (!_dbContext.Rooms.Any())
                await _dbContext.GenerateRoomAsync();
            if (!_dbContext.Comments.Any())
                await _dbContext.GenerateCommentsAsync(_userManager);
            if (!_dbContext.Logos.Any())
                await _dbContext.GenerateLogoAsync();
            if (!_dbContext.HotelBannerSections.Any())
                await _dbContext.GenerateHotelBannerSectionAsync();
            if (!_dbContext.HotelInfoSections.Any())
                await _dbContext.GenerateHotelInfoSectionAsync();
            if (!_dbContext.HotelTransitionSections.Any())
                await _dbContext.GenerateHotelTransitionAsync();
            if (!_dbContext.HotelShowcaseSections.Any())
                await _dbContext.GenerateHotelShowCaseAsync();
            if (!_dbContext.HotelCommentSections.Any())
                await _dbContext.GenerateCommentSectionAsync();
            if (!_dbContext.HotelPageBannerSections.Any())
                await _dbContext.GenerateHotelPageBannerAsync();
            if (!_dbContext.AboutPageBannerSections.Any())
                await _dbContext.GenerateAboutPageBannerAsync();
            if (!_dbContext.AboutPageCeoSections.Any())
                await _dbContext.GenerateAboutPageCeoAsync();
                await _dbContext.SaveChangesAsync();
        }
    }
}
