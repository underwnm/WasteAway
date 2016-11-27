using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int StringId { get; set; }

        public State State { get; set; }
    }
}