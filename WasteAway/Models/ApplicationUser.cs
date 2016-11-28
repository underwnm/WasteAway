using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("PickupAddress")]
        public int? PickupAddressId { get; set; }

        public Address PickupAddress { get; set; }

        [ForeignKey("PickupWeekday")]
        public int? PickupWeekdayId { get; set; }

        public Weekday PickupWeekday { get; set; }

        [ForeignKey("AlternatePickupWeekday")]
        public int? AlternatePickupWeekdayId { get; set; }

        public Weekday AlternatePickupWeekday { get; set; }

        [ForeignKey("LeaveDate")]
        public int? LeaveDateId { get; set; }

        public Date LeaveDate { get; set; }

        [ForeignKey("ReturnDate")]
        public int? ReturnDateId { get; set; }

        public Date ReturnDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}