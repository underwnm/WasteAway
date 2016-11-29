using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WasteAway.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public int? PickupAddressId { get; set; }
        public Address PickupAddress { get; set; }

        public int? PickupWeekdayId { get; set; }
        public Weekday PickupWeekday { get; set; }

        public int? AlternatePickupWeekdayId { get; set; }
        public Weekday AlternatePickupWeekday { get; set; }

        public int? LeaveDateId { get; set; }
        public Date LeaveDate { get; set; }

        public int? ReturnDateId { get; set; }
        public Date ReturnDate { get; set; }

        public int? BillId { get; set; }
        public Bill Bill { get; set; }

        public int? TruckId { get; set; }
        public Truck Truck { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}