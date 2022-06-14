using HotelListing.Data.Models;
using HotelListing.Services.Contracts;
using HotelListing.Services.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private AppUser _user;

        public AuthManager(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signInCredentials = GetSignInCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signInCredentials, claims);

            // serialize the jwt token into a string and return it
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signInCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");

            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));

            // create a token using options provided in the parameter
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signInCredentials
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, _user.Email)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSignInCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            // in production
            // var Key = Environment.GetEnvironmentVariable("JWT_KEY")
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("SecretKey").Value));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginDTO userDto)
        {
            _user = await _userManager.FindByEmailAsync(userDto.Email);

            if (_user == null)
            {
                return false;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(_user, userDto.Password);

            if (!isPasswordValid)
            {
                return false;
            }

            return true;
        }
    }
}
