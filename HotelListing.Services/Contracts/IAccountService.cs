using HotelListing.Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Contracts
{
    public interface IAccountService
    {
        Task<bool> RegisterNewUser(UserDTO userDTO);
        //Task<bool> LoginUser(LoginDTO loginDTO);
    }
}
