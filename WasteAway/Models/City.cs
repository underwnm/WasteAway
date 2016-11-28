using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int StateId { get; set; }

        public State State { get; set; }
    }
}