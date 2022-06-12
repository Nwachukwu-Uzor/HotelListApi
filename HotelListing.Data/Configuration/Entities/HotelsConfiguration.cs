using HotelListing.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Data.Configuration.Entities
{
    public class HotelsConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
