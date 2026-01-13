using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;


namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardMealComponentPartial(IApiService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await service.GetMealAsync();
            return View(result);
        }
    }
}
