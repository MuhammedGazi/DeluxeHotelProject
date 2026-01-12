using DeluxeHotel.DTOs.HotelDto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace DeluxeHotel.ViewComponents.Default
{
    public class _DefaultHotelComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string cityName, string checkIn, string checkOut)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return View(new List<RequestHotelDto>());
            }
            var result = await GetHotel(cityName, checkIn, checkOut);
            return View(result);
        }

        public async Task<string> GetDestId(string destName)
        {
            string? firstDestId;
            string encodedCity = Uri.EscapeDataString(destName);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={encodedCity}"),
                Headers =
                {
                    { "x-rapidapi-key", "019156258emsh10fb03ae6a920a0p13ff2cjsnfd330298dfcd" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result = JsonSerializer.Deserialize<LocationResponse>(body, options);
                firstDestId = result?.Data?.FirstOrDefault()?.DestId;
            }
            return firstDestId;
        }

        public async Task<List<RequestHotelDto>> GetHotel(string city, string checkIn, string checkOut)
        {
            List<RequestHotelDto> finalResult;
            string cityId = await GetDestId(city);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels" +
                $"?dest_id={cityId}" +
                $"&search_type=CITY" +
                $"&arrival_date={checkIn}" +
                $"&departure_date={checkOut}" +
                $"&adults=1" +
                $"&children_age=0%2C17" +
                $"&room_qty=1" +
                $"&page_number=1" +
                $"&units=metric" +
                $"&temperature_unit=c" +
                $"&languagecode=en-us" +
                $"&currency_code=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "019156258emsh10fb03ae6a920a0p13ff2cjsnfd330298dfcd" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Rootobject>(body);
                //firstDestId = result?.Data?.FirstOrDefault()?.DestId;
                finalResult = result?.data?.hotels.Select(h => new RequestHotelDto
                {
                    ImageUrl = h.property.photoUrls[0],
                    Name = h.property.name,
                    Price = $"{h.property.priceBreakdown.grossPrice.value:N2} {h.property.priceBreakdown.grossPrice.currency}",
                    Rating = h.property.reviewScore,
                    RatingWord = h.property.reviewScoreWord
                }).ToList();
            }
            return finalResult;
        }
    }
}
