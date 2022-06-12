using AutoMapper;
using HotelListing.Data.Models;
using HotelListing.Services.Contracts;
using HotelListing.Services.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> RegisterNewUser(UserDTO userDTO)
        {
            var user = _mapper.Map<AppUser>(userDTO);
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            return result.Succeeded;
        }

        //public async Task<bool> LoginUser(LoginDTO loginDTO)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);

        //    return result.Succeeded;
        //}
    }
}
