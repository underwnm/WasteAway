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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoute(RouteViewModel model)
        {
       
            return RedirectToAction("GoogleRoute", "Route", model);
        }

        public ActionResult GoogleRoute(RouteViewModel model)
        {
            return View();
        }
    }
}