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

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new AddressFormViewModel
            {
                States = _context.States.ToList(),
                Weekdays = _context.Weekdays.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(AddressFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.States = _context.States.ToList();
                viewModel.Weekdays = _context.Weekdays.ToList();
                return View("Create", viewModel);
            }
            var address = new Address
            {
                StreetAddressOne = viewModel.StreetAddressOne,
                StreetAddressTwo = viewModel.StreetAddressTwo,
                CityId = viewModel.CityId,
                ZipcodeId = viewModel.ZipcodeId
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}