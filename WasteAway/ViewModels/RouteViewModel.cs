using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class RouteViewModel
    {
        public decimal PickupCost;
        private readonly ApplicationDbContext _context;

        [Display(Name = "Truck Number")]
        public int TruckId { get; set; }
        public IEnumerable<Truck> Trucks { get; set; }

        public RouteViewModel(ApplicationDbContext context)
        {
            _context = context;
            PickupCost = (decimal) 5.99;
        }

        public void AssignPickups()
        {
            ResetTruckPickupList();
            SetTruckPickups(CreatePickupList(false));
        }

        private List<ApplicationUser> CreatePickupList(bool suspendPickup)
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
                user.Balance += PickupCost;
            }

            query = (from a in _context.Users
                     where a.PickupWeekday.Name 
                        == currentDay && a.AlternatePickupWeekdayId 
                        == null && !suspendPickup
                     select a);

            foreach (var user in query)
            {
                pickupList.Add(user);
                user.Balance += PickupCost;
            }

            return pickupList;
        }

        private void SetTruckPickups(List<ApplicationUser> users)
        {
            if (users == null) throw new ArgumentNullException(nameof(users));

            foreach (var user in users)
            {
                var pickup = new Pickup
                {
                    UserId = user.Id,
                };
                _context.Pickups.Add(pickup);
                _context.SaveChanges();

                foreach (var truck in _context.Trucks)
                {
                    truck.ZipcodeId = user.PickupAddress.ZipcodeId;
                    pickup.TruckId = truck.Id;
                    truck.Pickups.Add(pickup);
                }
            }
        }

        private void ResetTruckPickupList()
        {
            foreach (var truck in _context.Trucks)
            {
                truck.Pickups = new List<Pickup>();
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