using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class AddressFormViewModel
    {
        [Required]
        [Display(Name = "Street Address Line 1")]
        public string StreetAddressOne { get; set; }

        [Display(Name = "Street Address Line 2")]
        public string StreetAddressTwo { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }
        public IEnumerable<State> States { get; set; }

        [Required]
        [Display(Name = "City")]
        public int? CityId { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        public int? ZipcodeId { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        public int WeekdayId { get; set; }
        public IEnumerable<Weekday> Weekdays { get; set; }
    }
}