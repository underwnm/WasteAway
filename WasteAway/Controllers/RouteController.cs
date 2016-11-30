using System.Linq;
using System.Web.Mvc;
using WasteAway.Models;
using WasteAway.ViewModels;

namespace WasteAway.Controllers
{
    public class RouteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RouteController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult GetRoute()
        {
            var model = new RouteViewModel()
            {
                Trucks = _context.Trucks.ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoute(RouteViewModel model)
        {
            //model.AssignPickups();
            return RedirectToAction("GoogleRoute", "Route", model);
        }
        public ActionResult GoogleRoute(RouteViewModel model)
        {
            return View();
        }
    }
}