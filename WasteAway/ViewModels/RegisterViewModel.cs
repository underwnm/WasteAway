using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address Line*")]
        public string StreetAddressOne { get; set; }

        [Display(Name = " ")]
        public string StreetAddressTwo { get; set; }

        [Required]
        [Display(Name = "State*")]
        public int? StateId { get; set; }

        public IEnumerable<State> States { get; set; }

        [Required]
        [Display(Name = "City*")]
        public int CityId { get; set; }

        public IEnumerable<City> Cities { get; set; }

        [Required]
        [Display(Name = "Zipcode*")]
        public int ZipcodeId { get; set; }

        public IEnumerable<Zipcode> Zipcodes { get; set; }

        [Required]
        [Display(Name = "Weekly Pickup Day*")]
        public int WeekdayId { get; set; }

        public IEnumerable<Weekday> Weekdays { get; set; }

        public int CreateAddress(ApplicationDbContext context)
        {
            var address = new Address
            {
                StreetAddressOne = StreetAddressOne,
                StreetAddressTwo = StreetAddressTwo,
                CityId = CityId,
                ZipcodeId = ZipcodeId
            };
            context.Addresses.Add(address);
            context.SaveChanges();

            return address.Id;
        }
    }
}