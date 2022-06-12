using AutoMapper;
using HotelListing.Data.Models;
using HotelListing.Domain.Models;
using HotelListing.Services.DTOs.Country;
using HotelListing.Services.DTOs.Hotel;
using HotelListing.Services.DTOs.Users;
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

            CreateMap<UserDTO, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}
