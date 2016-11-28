using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class ChangePickupWeekdayViewModel
    {
        [Required]
        [Display(Name = "Pickup Day*")]
        public int WeekdayId { get; set; }
        public IEnumerable<Weekday> Weekdays { get; set; }
    }
}