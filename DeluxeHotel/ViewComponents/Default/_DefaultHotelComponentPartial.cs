using DeluxeHotel.DTOs.HotelDto;
using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;


namespace DeluxeHotel.ViewComponents.Default
{
    public class _DefaultHotelComponentPartial(IApiService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string cityName, string checkIn, string checkOut)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return View(new List<RequestHotelDto>());
            }
            var result = await service.GetHotelAsync(cityName, checkIn, checkOut);
            return View(result);
        }

    }
}
