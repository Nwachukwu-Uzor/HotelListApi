using AutoMapper;
using HotelListing.Domain.Models;
using HotelListing.Services.DTOs.Country;
using HotelListing.Services.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Configuration
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<CountryCreateDTO, Country>().ReverseMap();

            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<HotelCreateDTO, Hotel>().ReverseMap();
        }
    }
}
