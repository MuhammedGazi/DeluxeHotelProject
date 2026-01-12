using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
