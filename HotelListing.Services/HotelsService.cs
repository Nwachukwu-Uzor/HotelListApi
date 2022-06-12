using AutoMapper;
using HotelListing.Domain.Contracts;
using HotelListing.Services.Contracts;
using HotelListing.Services.DTOs.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services
{
    public class HotelsService : IHotelsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<HotelDTO>> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();

                return _mapper.Map<IList<HotelDTO>>(hotels);
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task<HotelDTO> GetHotelById(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(h => h.Id == id, new List<string> { "Country" });
                return _mapper.Map<HotelDTO>(hotel);
            } catch(Exception)
            {
                throw;
            }
        }
    }
}
