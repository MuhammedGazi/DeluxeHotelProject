using DeluxeHotel.DTOs.FilmDto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DeluxeHotel.ViewComponents.Dashboard
{
    public class _DashboardFilmsComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ViewFlimDto> result;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb236.p.rapidapi.com/api/imdb/most-popular-movies"),
                Headers =
                {
                    { "x-rapidapi-key", "019156258emsh10fb03ae6a920a0p13ff2cjsnfd330298dfcd" },
                    { "x-rapidapi-host", "imdb236.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<ViewFlimDto>>(body);
            }
            return View(result);
        }
    }
}
