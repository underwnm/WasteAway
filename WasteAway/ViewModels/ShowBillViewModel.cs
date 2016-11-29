using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class ShowBillViewModel
    {
        public decimal BillAmount;

        public void GetBill(string userId, ApplicationDbContext context)
        {
            var query = (from a in context.Users
                         where a.Id == userId
                         select new { a }).Single();
            var user = query.a;
            BillAmount = user.Balance;
        }
    }
}