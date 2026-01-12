using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardFinansViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
