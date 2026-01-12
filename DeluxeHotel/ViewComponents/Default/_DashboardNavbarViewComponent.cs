using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Default
{
    public class _DashboardNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
