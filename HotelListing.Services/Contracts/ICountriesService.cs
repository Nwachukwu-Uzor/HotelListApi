using HotelListing.Services.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Contracts
{
    public interface ICountriesService
    {
        Task<IList<CountryDTO>> GetCountries();
        Task<CountryDTO> GetCountryById(int id);
    }
}
