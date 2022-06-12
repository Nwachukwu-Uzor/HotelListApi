using HotelListing.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Data.Configuration.Entities
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
