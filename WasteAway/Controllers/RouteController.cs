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


        [Authorize]
        public ActionResult GetRoute()
        {
            var model = new RouteViewModel();
            model.GetRoute();
            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult GetRoute(RouteViewModel model)
        {
            model.SetWaypoints();
            return RedirectToAction("GoogleRoute", "Route", new { model = model});
        }

        public ActionResult GoogleRoute(RouteViewModel model)
        {

            return View(model);
        }
    }
}