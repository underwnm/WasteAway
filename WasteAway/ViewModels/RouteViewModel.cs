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
            SetPickups(GetPickupList(false));
            AssignTrucks(GetZipcodes());
        }

        private List<ApplicationUser> GetPickupList(bool suspendPickup)
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
                user.Bill.Amount += (decimal) 4.99;
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

        private List<Zipcode> GetZipcodes()
        {
            var pickupZipcodes = _context.Pickups.Select(pickup => pickup.User.PickupAddress.Zipcode).ToList();
            return pickupZipcodes.Distinct().ToList();
        }
        private void AssignTrucks(List<Zipcode> pickupZipcodes)
        {
            if (pickupZipcodes == null) throw new ArgumentNullException(nameof(pickupZipcodes));

            var i = 0;
            foreach (var truck in _context.Trucks)
            {
                if (i > pickupZipcodes.Count)
                {
                    truck.ZipcodeId = null;
                }
                else
                {
                    truck.ZipcodeId = pickupZipcodes[i].Id;
                }
                i++;
            }

            for (var j = i; j < pickupZipcodes.Count; j++)
            {
                var newTruck = new Truck {ZipcodeId = pickupZipcodes[j].Id};
                _context.Trucks.Add(newTruck);
            }
            _context.SaveChanges();
        }
    }
}