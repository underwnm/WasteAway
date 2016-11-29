using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Pickup
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int? TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}