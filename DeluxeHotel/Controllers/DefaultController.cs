using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotel.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetHotelComponent(string cityName, string checkIn, string checkOut)
    {
        ViewBag.SehirAdi = cityName;
        return ViewComponent("_DefaultHotelComponentPartial", new { cityName = cityName, checkIn = checkIn, checkOut = checkOut });
    }
}








