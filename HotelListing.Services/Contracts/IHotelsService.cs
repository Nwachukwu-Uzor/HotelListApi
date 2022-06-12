using HotelListing.Services.DTOs.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListing.Services.Contracts
{
    public interface IHotelsService
    {
        Task<IList<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotelById(int id);
    }
}
