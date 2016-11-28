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
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.States = _context.States.ToList();
                viewModel.Weekdays = _context.Weekdays.ToList();
                return View("Create", viewModel);
            } 
                var city = new City
                {
                    StateId = viewModel.StateId,
                    Name = viewModel.City
                };
                _context.Cities.Add(city);
                _context.SaveChanges();

                var zipcode = new Zipcode
                {
                    Name = viewModel.ZipcodeId,
                };
                _context.Zipcodes.Add(zipcode);
                _context.SaveChanges();

                var address = new Address
                {
                    StreetAddressOne = viewModel.StreetAddressOne,
                    StreetAddressTwo = viewModel.StreetAddressTwo,
                    CityId = city.Id,
                    ZipcodeId = zipcode.Id
                };
                _context.Addresses.Add(address);
                _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}