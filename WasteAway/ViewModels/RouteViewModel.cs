using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class RouteViewModel
    {
        private readonly decimal _pickupCost;
        private readonly ApplicationDbContext _context;

        public RouteViewModel(ApplicationDbContext context)
        {
            _context = context;
            _pickupCost = (decimal) 5.99;
        }

        public void AssignPickups()
        {
            ClearPickups();
            SetPickups(GetPickupList(false));
        }

        private List<ApplicationUser> GetPickupList(bool suspendPickup)
        {
            var pickupList = new List<ApplicationUser>();
            var date = new DateTime();
            var currentDay = date.DayOfWeek.ToString();

            var query = (from a in _context.Users
                         where a.AlternatePickupWeekday.Name 
                            == currentDay && !suspendPickup
                         select a);

            foreach (var user in query)
            {
                pickupList.Add(user);
                user.AlternatePickupWeekdayId = null;
                user.Bill.Amount += _pickupCost;
            }

            query = (from a in _context.Users
                     where a.PickupWeekday.Name 
                        == currentDay && a.AlternatePickupWeekdayId 
                        == null && !suspendPickup
                     select a);

            foreach (var user in query)
            {
                pickupList.Add(user);
                user.Bill.Amount += _pickupCost;
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

                foreach (var truck in _context.Trucks)
                {
                    truck.ZipcodeId = user.PickupAddress.ZipcodeId;
                    truck.Pickups.Add(pickup);
                }
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