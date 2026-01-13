using DeluxeHotel.Services.GeminiServices;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardRouteComponentPartial(IGeminiService _service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string? cityName)
        {
            cityName = HttpContext.Session.GetString("SelectedCity") ?? "Ankara";
            var dynamicHtml = await _service.GetHistoricalRouteHtml(cityName);

            return View("Default", dynamicHtml);
        }
    }
}
