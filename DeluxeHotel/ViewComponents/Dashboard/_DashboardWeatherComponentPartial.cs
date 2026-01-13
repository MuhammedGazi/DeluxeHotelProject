using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardWeatherComponentPartial(IApiService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string? cityName)
        {
            cityName = HttpContext.Session.GetString("SelectedCity") ?? "Ankara";
            var result = await service.GetWeatherAsync(cityName);
            return View(result);
        }
    }
}
