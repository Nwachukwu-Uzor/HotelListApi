using HotelListing.Services.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.DTOs.Hotel
{
    public class HotelDTO : HotelCreateDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
