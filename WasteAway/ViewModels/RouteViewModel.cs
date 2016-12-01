using System;
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

        private ApplicationDbContext _context;
        private List<string> _route;

        public RouteViewModel()
        {
            _context = new ApplicationDbContext();
            _route = new List<string>();
        }

        public void GetRoute()
        {
            var results = _context.Trucks
                .Where(a => a.Pickups.Count > 0)
                .Select(a => a)
                .ToList();

            Trucks = results;
        }

        public void SetWaypoints()
        {
            var pickups = _context.Pickups
                .Where(a => a.TruckId == TruckId)
                .Select(a => a.UserId)
                .ToList();

            var addressId = new List<int?>();
            for (int i = 0; i < pickups.Count; i++)
            {
                var results = _context.Users
                    .Where(a => a.Id == pickups[i])
                    .Select(a => a.PickupAddressId)
                    .SingleOrDefault();
                addressId.Add(results);
            }

            var addresses = new List<Address>();
            for (int i = 0; i < pickups.Count; i++)
            {
                var results = _context.Addresses
                    .SingleOrDefault(a => a.Id == addressId[i].Value);
                addresses.Add(results);
            }

            for (int i = 0; i < addresses.Count; i++)
            {
                var streetAddressOne = addresses[i].StreetAddressOne;
                var streetAddressTwo = addresses[i].StreetAddressTwo;
                var city = addresses[i].City.Name;
                var state = addresses[i].City.State.Name;
                _route.Add($"{streetAddressOne} {streetAddressTwo}, {city}, {state}");
            }


//            var route = new List<string>();
//            foreach (var address in addresses)
//            {
//                var streetAddressOne = address.StreetAddressOne;
//                var streetAddressTwo = address.StreetAddressTwo;
//                var city = address.City.Name;
//                var state = address.City.State.Name;
//                route.Add($"{streetAddressOne} {streetAddressTwo}, {city}, {state}");
//            }


        }

        public string GetGoogleApi()
        {
            var link = "https://maps.googleapis.com/maps/api/directions/json?";
            var waypoints = AddAddressToRoute();
            var key = "&key=AIzaSyClwtEuYnCM7X2XwMdR9x4D56tbw5KehIM&callback=initialize";
            return link + waypoints + key;
        }

        private string AddAddressToRoute()
        {
            if (_route == null) throw new ArgumentNullException(nameof(_route));
            var start = _route[0];
            var end = _route[_route.Count - 1];
            var waypoints = "";
            for (int i = 1; i < _route.Count-1; i++)
            {
                if (i != _route.Count - 2)
                {
                    waypoints += "|" + _route[i];
                }
                
            }

            return "origin=" + start + "&destination=" + end + "&waypoints=optimize:true" + waypoints;
        }
    }
}