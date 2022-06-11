using HotelListing.Services.DTOs.Hotel;
using System.Collections.Generic;

namespace HotelListing.Services.DTOs.Country
{
    public class CountryDTO : CountryCreateDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }
}
