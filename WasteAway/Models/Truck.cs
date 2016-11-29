using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Truck
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public int? ZipcodeId { get; set; }
        public Zipcode Zipcode { get; set; }

        public List<Pickup> Pickups { get; set; }

        public Truck()
        {
            Pickups = new List<Pickup>();
        }
    }
}