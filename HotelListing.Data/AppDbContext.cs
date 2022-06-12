using HotelListing.Data.Configuration.Entities;
using HotelListing.Data.Models;
using HotelListing.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new CountriesConfiguration());
            builder.ApplyConfiguration(new HotelsConfiguration());
        }
    }
}
