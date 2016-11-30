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

        public void GetRoute(ApplicationDbContext context)
        {
            var results = context.Trucks
                .Where(a => a.Pickups.Count == 0)
                .Select(a => a)
                .ToList();

            Trucks = results;
        }
    }
}