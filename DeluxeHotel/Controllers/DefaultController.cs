using DeluxeHotel.Services.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.Controllers;

public class DefaultController(IApiService service) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> HotelDetails(int id = 191605, string? checkin = null, string? checkout = null)
    {
        checkin ??= DateTime.Now.ToString("yyyy-MM-dd");
        checkout ??= DateTime.Now.AddDays(5).ToString("yyyy-MM-dd");

        var result = await service.GetHotelDetailAsync(id, checkin, checkout);
        return View(result);
    }

    public IActionResult GetHotelComponent(string cityName, string checkIn, string checkOut)
    {
        ViewBag.SehirAdi = cityName;
        return ViewComponent("_DefaultHotelComponentPartial", new { cityName = cityName, checkIn = checkIn, checkOut = checkOut });
    }
}