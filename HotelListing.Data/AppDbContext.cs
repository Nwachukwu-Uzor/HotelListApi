using HotelListing.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Nigeria",
                    ShortName = "NGR"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "England",
                     ShortName = "ENG"
                 },
                  new Country
                  {
                      Id = 3,
                      Name = "Brazil",
                      ShortName = "BZL"
                  }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Eko Hotels and Suite",
                    CountryId = 1,
                    Rating = 4.5,
                    Address = "VI, Lagos"
                },
                 new Hotel
                 {
                     Id = 2,
                     Name = "Golden Tulip",
                     CountryId = 1,
                     Rating = 4.2,
                     Address = "Warri, Delta"
                 },
                  new Hotel
                  {
                      Id = 3,
                      Name = "Continental Hotels",
                      CountryId = 1,
                      Rating = 4.7,
                      Address = "Ikoyi, Lagos"
                  },
                  new Hotel
                  {
                      Id = 4,
                      Name = "The Miltons",
                      CountryId = 2,
                      Rating = 4.5,
                      Address = "Greenwich, London"
                  },
                  new Hotel
                  {
                      Id = 5,
                      Name = "El Cabritos",
                      CountryId = 3,
                      Rating = 4.8,
                      Address = "Rio De Janeiro"
                  }
            );
        }
    }
}
