using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string StreetAddressOne { get; set; }

        public string StreetAddressTwo { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }

        [Required]
        public int ZipcodeId { get; set; }

        public Zipcode Zipcode { get; set; }
    }
}