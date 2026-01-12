using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Default
{
    public class _DashboardBannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
