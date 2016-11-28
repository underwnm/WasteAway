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
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Street Address Line*")]
        public string StreetAddressOne { get; set; }

        [Display(Name = "Street Address Line Cont.")]
        public string StreetAddressTwo { get; set; }

        [Required]
        [Display(Name = "State*")]
        public int StateId { get; set; }
        public IEnumerable<State> States { get; set; }

        [Required]
        [Display(Name = "City*")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Zipcode*")]
        public string ZipcodeId { get; set; }

        [Required]
        [Display(Name = "Weekly Pickup Day*")]
        public int WeekdayId { get; set; }
        public IEnumerable<Weekday> Weekdays { get; set; }

        public int CreateAddress(RegisterViewModel model, ApplicationDbContext context)
        {
            var city = new City
            {
                StateId = model.StateId,
                Name = model.City
            };
            context.Cities.Add(city);
            context.SaveChanges();

            var zipcode = new Zipcode
            {
                Name = model.ZipcodeId
            };
            context.Zipcodes.Add(zipcode);
            context.SaveChanges();

            var address = new Address
            {
                StreetAddressOne = model.StreetAddressOne,
                StreetAddressTwo = model.StreetAddressTwo,
                CityId = city.Id,
                ZipcodeId = zipcode.Id
            };
            context.Addresses.Add(address);
            context.SaveChanges();

            return address.Id;
        }
    }
}