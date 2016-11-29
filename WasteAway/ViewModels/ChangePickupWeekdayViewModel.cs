using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class ChangePickupWeekdayViewModel
    {
        [Required]
        [Display(Name = "Pickup Day*")]
        public int WeekdayId { get; set; }
        public IEnumerable<Weekday> Weekdays { get; set; }

        public void ChangePickup(string userId, ApplicationDbContext context)
        {
            var query = (from a in context.Users
                         where a.Id == userId
                         select new { a }).Single();
            var user = query.a;
            user.PickupWeekdayId = WeekdayId;
            context.SaveChanges();
        }

        public void ChangeAlternatePickup(string userId, ApplicationDbContext context)
        {
            var result = context.Users.Where(a => a.Id == userId).ToList();

            foreach (var user in result)
            {
                user.PickupWeekdayId = WeekdayId;
            }

//            var query = (from a in context.Users
//                         where a.Id == userId
//                         select new { a }).Single();
            //var user = query.a;
            //user.AlternatePickupWeekdayId = WeekdayId;
            context.SaveChanges();
        }
    }
}