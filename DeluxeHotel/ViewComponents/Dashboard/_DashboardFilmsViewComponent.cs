using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardFilmsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
