using HotelListing.Services.Contracts;
using HotelListing.Services.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountService;
        private readonly IAuthManager _authManager;

        public AccountsController(IAccountService accountService, ILogger<AccountsController> logger, IAuthManager authManager)
        {
            _accountService = accountService;
            _logger = logger;
            _authManager = authManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration request came in for {userDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var success = await _accountService.RegisterNewUser(userDTO);

                if (!success)
                {
                    return BadRequest("Registration attempt failed attempt failed");
                }

                return Accepted();
            } catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(Register)}");
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _authManager.ValidateUser(loginDTO);

                if (!result)
                {
                    return Unauthorized(loginDTO);
                }

                return Accepted(new { Token = await _authManager.CreateToken()});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(Login)}");
                return Problem($"Something went wrong in {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
