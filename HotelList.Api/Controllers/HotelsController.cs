using HotelListing.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
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
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsService _hotelService;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(IHotelsService hotelService, ILogger<HotelsController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _hotelService.GetHotels();

                return Ok(hotels);
            } catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetHotels)} in {nameof(HotelsController)}");
                return StatusCode(500, "We are experiencing difficulty processing your request, please try again later");
            }
        }

        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hotelService.GetHotelById(id);

                return Ok(hotel);
            } catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetHotelById)} in {nameof(HotelsController)}");
                return StatusCode(500, "We are experiencing difficulty processing your request, please try again later");
            }
        }
    }
}
