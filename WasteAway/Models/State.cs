using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class State
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}