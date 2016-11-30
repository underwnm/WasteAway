using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class RouteViewModel
    {
        [Display(Name = "Truck Number")]
        public int TruckId { get; set; }
        public IEnumerable<Truck> Trucks { get; set; }
    }
}