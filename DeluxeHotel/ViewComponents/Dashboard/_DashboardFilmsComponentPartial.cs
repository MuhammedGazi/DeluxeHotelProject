using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardFilmsComponentPartial(IApiService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await service.GetFlimAsync();
            return View(result);
        }
    }
}
