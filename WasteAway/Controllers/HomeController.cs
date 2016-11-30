using System.Web.Mvc;
using WasteAway.Models;
using WasteAway.ViewModels;

namespace WasteAway.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetRoute()
        {
            var model = new RouteViewModel();
            model.GetRoute(_context);

            return View(model);
        }
    }
}