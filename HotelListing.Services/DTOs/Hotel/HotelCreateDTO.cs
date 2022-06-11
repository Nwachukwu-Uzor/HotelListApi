using System;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Services.DTOs.Hotel
{
    public class HotelCreateDTO
    {
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Hotel name is too long")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Hotel address is too long")]
        public string Address { get; set; }
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
