using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardOilViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
