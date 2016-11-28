using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}