using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Default
{
    public class _DashboardFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
