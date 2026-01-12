using DeluxeHotel.DTOs.OilDto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardOilComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string city = "adiyaman")
        {
            ViewBag.ilAdı = city;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://hasanadiguzel.com.tr/api/akaryakit/sehir={city}");

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var fuelRoot = JsonSerializer.Deserialize<FuelRoot>(body, options);

                    var result = fuelRoot?.data?.FirstOrDefault();

                    return View(result);
                }
            }
            return View(new FuelItem());
        }
    }
}
