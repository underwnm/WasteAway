using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class ChangeAddressViewModel
    {
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

        public int ChangeAddress(ApplicationDbContext context)
        {
            var city = new City
            {
                StateId = StateId,
                Name = City
            };
            context.Cities.Add(city);
            context.SaveChanges();

            var zipcode = new Zipcode
            {
                Name = ZipcodeId,
            };
            context.Zipcodes.Add(zipcode);
            context.SaveChanges();

            var address = new Address
            {
                StreetAddressOne = StreetAddressOne,
                StreetAddressTwo = StreetAddressTwo,
                CityId = city.Id,
                ZipcodeId = zipcode.Id
            };
            context.Addresses.Add(address);
            context.SaveChanges();

            return address.Id;
        }

        public void ChangePickupAddressToNewAddress(string userId, int addressId, ApplicationDbContext context)
        {
            var query = (from a in context.Users
                         where a.Id == userId
                         select new { a }).Single();
            var user = query.a;
            user.PickupAddressId = addressId;
            context.SaveChanges();
        }
    }
}