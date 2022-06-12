using AutoMapper;
using HotelListing.Domain.Contracts;
using HotelListing.Services.Contracts;
using HotelListing.Services.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<CountryDTO>> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                return _mapper.Map<IList<CountryDTO>>(countries);
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task<CountryDTO> GetCountryById(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels"});
                return _mapper.Map<CountryDTO>(country);
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
