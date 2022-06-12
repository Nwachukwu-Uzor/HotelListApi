using HotelListing.Services.Contracts;
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
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        private readonly ILogger<CountriesController> _logger;
        public CountriesController(ICountriesService countriesService, ILogger<CountriesController> logger)
        {
            _countriesService = countriesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _countriesService.GetCountries();
                return Ok(countries);
            } catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCountries)} controller");
                return StatusCode(500, "Something went wrong, please try again later");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            try
            {
                var country = await _countriesService.GetCountryById(id);
                return Ok(country);
            } catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCountryById)} controller");
                return StatusCode(500, "Something went wrong, please try again later");
            }
        } 
    }
}
