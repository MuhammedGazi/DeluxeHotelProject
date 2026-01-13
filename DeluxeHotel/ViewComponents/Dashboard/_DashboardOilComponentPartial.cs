using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardOilComponentPartial(IApiService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string? city)
        {
            city = HttpContext.Session.GetString("SelectedCity") ?? "Ankara";
            ViewBag.ilAdı = city;
            var result = await service.GetOilAsync(city);
            return View(result);
        }
    }
}
