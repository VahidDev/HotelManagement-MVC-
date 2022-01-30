using Hotel.Models;
using Hotel.Models.WebsiteSections;
using Hotel.Models.WebsiteSections.AboutPageSections;
using Hotel.Models.WebsiteSections.SubWebsiteSections;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Models.Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Layout> Logos{ get; set; }
        public DbSet<HotelBannerSection> HotelBannerSections { get; set; }
        public DbSet<HotelInfoSection> HotelInfoSections { get; set; }
        public DbSet<HotelTransitionSection> HotelTransitionSections { get; set; }
        public DbSet<HotelTransitionSectionImage> HotelTransitionSectionImages { get; set; }
        public DbSet<HotelShowcaseSection> HotelShowcaseSections { get; set; }
        public DbSet<HotelCommentSection> HotelCommentSections { get; set; }
        public DbSet<HotelPageBannerSection> HotelPageBannerSections { get; set; }
        public DbSet<AboutPageBannerSection> AboutPageBannerSections{ get; set; }
        public DbSet<AboutPageCeoSection> AboutPageCeoSections { get; set; }
    }
}
