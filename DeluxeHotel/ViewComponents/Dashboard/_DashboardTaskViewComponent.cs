using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardTaskViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
