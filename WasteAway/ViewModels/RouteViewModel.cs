using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var pickups = new List<ApplicationUser>();
            var date = new DateTime();
            var currentDay = date.DayOfWeek.ToString();

            var results = _context.Users
                .Where(a => a.AlternatePickupWeekday.Name == currentDay && !suspendPickup)
                .ToList();

            foreach (var user in results)
            {
                pickups.Add(user);
                user.AlternatePickupWeekdayId = null;
                user.Balance += PickupCost;
            }

            results = _context.Users
                    .Where(a => a.PickupWeekday.Name == currentDay)
                    .Where(a => a.AlternatePickupWeekdayId == null && !suspendPickup)
                    .ToList();

            foreach (var user in results)
            {
                pickups.Add(user);
                user.Balance += PickupCost;
            }

            return pickups;
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
    }
}