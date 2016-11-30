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
            var model = new RouteViewModel(_context);

            model.AssignPickups();
            return View(model);
        
    }
}