using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Day
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}