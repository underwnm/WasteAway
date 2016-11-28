using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Month
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}