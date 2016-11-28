using System.ComponentModel.DataAnnotations;

namespace WasteAway.Models
{
    public class Date
    {
        public int Id { get; set; }

        [Required]
        public int DayId { get; set; }

        public Day Day { get; set; }

        [Required]
        public int MonthId { get; set; }

        public Month Month { get; set; }

        [Required]
        public int YearId { get; set; }

        public Year Year { get; set; }

    }
}