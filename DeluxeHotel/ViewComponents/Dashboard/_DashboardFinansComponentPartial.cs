using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardFinansComponentPartial(IApiService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await service.GetFinanceAsync();
            return View(result);
        }
    }
}
