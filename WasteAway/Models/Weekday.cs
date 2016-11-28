using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Weekday
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}