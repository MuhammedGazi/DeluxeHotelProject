using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Default
{
    public class _DashboardHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
