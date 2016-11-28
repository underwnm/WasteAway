using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class VacationViewModel
    {

        [Required]
        [Display(Name = "Day")]
        public int DayId { get; set; }
        public IEnumerable<Day> Days { get; set; }

        [Required]
        [Display(Name = "Month")]
        public int MonthId { get; set; }
        public IEnumerable<Month> Months { get; set; }

        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; }

        public void SetLeaveDate(string userId, ApplicationDbContext context)
        {
            var year = new Year
            {
                Name = Year
            };
            context.Years.Add(year);
            context.SaveChanges();

            var leaveDate = new Date
            {
                DayId = DayId,
                MonthId = MonthId,
                YearId = year.Id
            };
            context.Dates.Add(leaveDate);
            context.SaveChanges();

            var query = (from a in context.Users
                         where a.Id == userId
                         select new { a }).Single();
            var user = query.a;
            user.LeaveDateId = leaveDate.Id;
            context.SaveChanges();
        }

        public void SetReturnDate(string userId, ApplicationDbContext context)
        {
            var year = new Year
            {
                Name = Year
            };
            context.Years.Add(year);
            context.SaveChanges();

            var returnDate = new Date
            {
                DayId = DayId,
                MonthId = MonthId,
                YearId = year.Id
            };
            context.Dates.Add(returnDate);
            context.SaveChanges();

            var query = (from a in context.Users
                         where a.Id == userId
                         select new { a }).Single();
            var user = query.a;
            user.ReturnDateId = returnDate.Id;
            context.SaveChanges();
        }
    }
}