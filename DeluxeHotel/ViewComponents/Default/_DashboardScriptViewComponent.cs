using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Default
{
    public class _DashboardScriptViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
