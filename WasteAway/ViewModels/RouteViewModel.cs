using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class RouteViewModel
    {
        private readonly ApplicationDbContext _context;

        public RouteViewModel(ApplicationDbContext context)
        {
            _context = context;
        }
                public void AssignPickups()
                {
                    ClearPickups();
                    SetPickups(GetUserList(false));
                }

        private List<ApplicationUser> GetUserList(bool suspendPickup)
        {
            var pickupList = new List<ApplicationUser>();
            var date = new DateTime();
            var currentDay = date.DayOfWeek.ToString();

            var query = (from a in _context.Users
                         where a.AlternatePickupWeekday.Name == currentDay && !suspendPickup
                         select a);

            foreach (var user in query)
            {
                pickupList.Add(user);
                user.AlternatePickupWeekdayId = null;
            }

            query = (from a in _context.Users
                     where a.PickupWeekday.Name == currentDay && a.AlternatePickupWeekdayId == null && !suspendPickup
                     select a);

            foreach (var user in query)
            {
                pickupList.Add(user);
            }

            return pickupList;
        }

        private void SetPickups(List<ApplicationUser> users)
        {
            if (users == null) throw new ArgumentNullException(nameof(users));

            foreach (var user in users)
            {
                var pickup = new Pickup {UserId = user.Id};
                _context.Pickups.Add(pickup);
                _context.SaveChanges();
            }
        }
        
        private static void ClearPickups()
        {
            const string truncate = "TRUNCATE TABLE Pickups";
            var command = new SqlCommand(truncate);
            command.ExecuteNonQuery();
        }
    }
}