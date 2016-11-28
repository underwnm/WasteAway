using System.Linq;
using System.Web.Mvc;
using WasteAway.Models;
using WasteAway.ViewModels;

namespace WasteAway.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Create()
        {
            var viewModel = new AddressFormViewModel
            {
                States = _context.States.ToList(),
                Weekdays = _context.Weekdays.ToList()
            };

            return View(viewModel);
        }
    }
}