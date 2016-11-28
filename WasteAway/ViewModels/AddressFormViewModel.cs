using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class AddressFormViewModel
    {
        [Required]
        [Display(Name = "Street Address Line")]
        public string StreetAddressOne { get; set; }

        [Display(Name = "Street Address Line Cont.")]
        public string StreetAddressTwo { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }
        public IEnumerable<State> States { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        public string ZipcodeId { get; set; }

        [Required]
        [Display(Name = "Weekly Pickup Day")]
        public int WeekdayId { get; set; }
        public IEnumerable<Weekday> Weekdays { get; set; }
    }
}