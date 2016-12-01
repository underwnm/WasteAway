using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class RouteViewModel
    {
        [Display(Name = "Truck Number")]
        public int TruckId { get; set; }
        public IEnumerable<Truck> Trucks { get ; set; }

        public int Route = 0;
        private ApplicationDbContext _context;
        public List<string> AddressesForPickup;


        public RouteViewModel()
        {
            AddressesForPickup = new List<string>();

        }

        public void FindTrucksWithPickups(ApplicationDbContext context)
        {
            _context = context;
            var results = _context.Trucks
                .Where(a => a.Pickups.Count > 0)
                .Select(a => a)
                .ToList();

            Trucks = results;
        }

        private void AddAddress(string userId)
        {
            var user = _context.Users
                .Where(a => a.Id == userId)
                .Select(a => a)
                .Single();

            var address = _context.Addresses
                .Where(a => a.Id == user.PickupAddressId)
                .Select(a => a)
                .Single();

            var city = _context.Cities
                .Where(a => a.Id == address.CityId)
                .Select(a => a)
                .Single();

            var state = _context.States
                .Where(a => a.Id == city.StateId)
                .Select(a => a)
                .Single();

            var addressOfUser = $"{address.StreetAddressOne} {address.StreetAddressTwo}, {city.Name}, {state.Name}".Replace(" ", "+"); ;
            AddressesForPickup.Add(addressOfUser);
        }

        public void SetWaypoints()
        {
            var pickups = _context.Pickups
                .Where(a => a.TruckId == Route)
                .Select(a => a)
                .ToList();

            foreach (var pickup in pickups)
            {
                AddAddress(pickup.UserId);
            }
            AddressesForPickup = AddressesForPickup.Distinct().ToList();
        }

        public string GetGoogleApi()
        {

            SetWaypoints();
            var waypoints = AddAddressToRoute();
            const string key = "key=AIzaSyDgaGKD2x4WZF367-tX6vUmF06vUXT3t4A";
            
            return "https://www.google.com/maps/embed/v1/directions?" + key + waypoints; ;
        }

        private string AddAddressToRoute()
        {
            
            var origin = AddressesForPickup[0];
            var destination = AddressesForPickup[AddressesForPickup.Count - 1];
            var waypoints = "";
            for (var i = 1; i < AddressesForPickup.Count - 1; i++)
            {
                if (i != 1)
                {
                    waypoints += "|";
                }
                waypoints += AddressesForPickup[i];

            }
            if (waypoints != "")
            {
                waypoints = "&waypoints=" + waypoints;
            }

            return "&origin=" + origin + "&destination=" + destination + waypoints;
        }
    }
}