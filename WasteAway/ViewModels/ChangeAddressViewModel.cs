using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class ChangeAddressViewModel
    {
        [Required]
        [Display(Name = "Address Line*")]
        public string StreetAddressOne { get; set; }

        [Display(Name = "Address Line Cont.")]
        public string StreetAddressTwo { get; set; }

        [Required]
        [Display(Name = "State*")]
        public int StateId { get; set; }

        public IEnumerable<State> States { get; set; }

        [Required]
        [Display(Name = "City*")]
        public int CityId { get; set; }

        public IEnumerable<City> Cities { get; set; }

        [Required]
        [Display(Name = "Zipcode*")]
        public int ZipcodeId { get; set; }

        public IEnumerable<Zipcode> Zipcodes { get; set; }

        public int ChangeAddress(ApplicationDbContext context)
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

        public void ChangePickupAddressToNewAddress(string userId, int addressId, ApplicationDbContext context)
        {
            var result = context.Users.Where(u => u.Id == userId).ToList();

            foreach (var user in result)
            {
                user.PickupAddressId = addressId;
            }

            context.SaveChanges();
        }
    }
}