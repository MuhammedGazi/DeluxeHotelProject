using DeluxeHotel.DTOs.FinanceDto;
using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardFinansComponentPartial(IApiService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var financeTask = service.GetFinanceAsync();
            var coinTask = service.GetCoinAsync();

            await Task.WhenAll(financeTask, coinTask);

            var financeResult = await financeTask;
            var coinResult = await coinTask;

            var dto = new ResultViewDto()
            {
                FinanceDto = financeResult,
                CoinDto = coinResult
            };

            return View(dto);
        }
    }
}
