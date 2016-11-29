using System.Linq;
using WasteAway.Models;

namespace WasteAway.ViewModels
{
    public class ShowBillViewModel
    {
        public int BillId { get; set; }
        public decimal BillAmount;

        public void GetBill(string userId, ApplicationDbContext context)
        {
            var query = (from a in context.Users
                         where a.Id == userId
                         select new { a }).Single();
            var user = query.a;
            BillAmount = GetBillAmount(user.BillId, context);
        }

        public decimal GetBillAmount(int? billId, ApplicationDbContext context)
        {
            if (billId == null) return 0;

            var query = (from a in context.Bills
                where a.Id == billId
                select new {a.Amount}).Single();

            return query.Amount;
        }
    }
}