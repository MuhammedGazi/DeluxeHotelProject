using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardRouteViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
