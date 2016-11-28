using System;
using System.ComponentModel.DataAnnotations;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class VacationViewModel
    {
        [Required]
        public int DayId { get; set; }
        public Day Day { get; set; }

        [Required]
        public int MonthId { get; set; }
        public Month Month { get; set; }

        [Required]
        public int YearId { get; set; }
        public Year Year { get; set; }

        public DateTime Test()
        {
            var leaveDate = new DateTime(DayId, MonthId, YearId);

            return leaveDate;
        }
    }
}