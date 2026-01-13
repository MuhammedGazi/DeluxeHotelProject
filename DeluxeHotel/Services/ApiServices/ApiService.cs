using DeluxeHotel.DTOs.FilmDto;
using DeluxeHotel.DTOs.FinanceDto;
using DeluxeHotel.DTOs.HotelDto;
using DeluxeHotel.DTOs.MealDto;
using DeluxeHotel.DTOs.OilDto;
using DeluxeHotel.DTOs.WeatherDto;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;
using Rootobject = DeluxeHotel.DTOs.WeatherDto.Rootobject;

namespace DeluxeHotel.Services.ApiServices
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;
        private readonly string _filmKey;
        private readonly string _weatherKey;
        private readonly string _hotelKey;
        private readonly string _financeKey;
        public ApiService(IConfiguration configuration, HttpClient client)
        {
            _filmKey = configuration["RapidApiKeys:FilmsKey"];
            _weatherKey = configuration["RapidApiKeys:WeatherKey"];
            _hotelKey = configuration["RapidApiKeys:HotelKey"];
            _financeKey = configuration["RapidApiKeys:FinanceKey"];
            _client = client;
        }
        public async Task<List<ViewFlimDto>> GetFlimAsync()
        {
            List<ViewFlimDto> result;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb236.p.rapidapi.com/api/imdb/most-popular-movies"),
                Headers =
                {
                    { "x-rapidapi-key", $"{_filmKey}" },
                    { "x-rapidapi-host", "imdb236.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                result = System.Text.Json.JsonSerializer.Deserialize<List<ViewFlimDto>>(body);
            }
            return result;
        }
        public async Task<string> GetDestId(string destName)
        {
            string? firstDestId;
            string encodedCity = Uri.EscapeDataString(destName);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={encodedCity}"),
                Headers =
                {
                    { "x-rapidapi-key", $"{_hotelKey}" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result = System.Text.Json.JsonSerializer.Deserialize<LocationResponse>(body, options);
                firstDestId = result?.Data?.FirstOrDefault()?.DestId;
            }
            return firstDestId;
        }
        public async Task<List<RequestHotelDto>> GetHotelAsync(string city, string checkIn, string checkOut)
        {
            List<RequestHotelDto> finalResult;
            string cityId = await GetDestId(city);
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
                    { "x-rapidapi-key", $"{_hotelKey}" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = System.Text.Json.JsonSerializer.Deserialize<DTOs.HotelDto.Rootobject>(body);
                finalResult = result?.data?.hotels.Select(h => new RequestHotelDto
                {
                    ImageUrl = h.property.photoUrls[0],
                    Name = h.property.name,
                    Price = $"{h.property.priceBreakdown.grossPrice.value:N2} {h.property.priceBreakdown.grossPrice.currency}",
                    Rating = h.property.reviewScore,
                    RatingWord = h.property.reviewScoreWord,
                    HotelId = h.property.id
                }).ToList();
            }
            return finalResult;
        }

        public async Task<ViewMealDto> GetMealAsync()
        {
            var response = await _client.GetAsync("https://www.themealdb.com/api/json/v1/1/random.php");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MealDBResponse>(body);
                var meal = result.meals.FirstOrDefault();

                if (meal != null)
                {
                    var resultMealDto = new ViewMealDto
                    {
                        Title = meal.strMeal,
                        Category = meal.strCategory,
                        Area = meal.strArea,
                        Instructions = meal.strInstructions,
                        Image = meal.strMealThumb
                    };
                    return resultMealDto;
                }
            }
            return new ViewMealDto();
        }

        public async Task<FuelItem> GetOilAsync(string city)
        {

            var response = await _client.GetAsync($"http://hasanadiguzel.com.tr/api/akaryakit/sehir={city}");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var fuelRoot = System.Text.Json.JsonSerializer.Deserialize<FuelRoot>(body, options);

                var result = fuelRoot?.data?.FirstOrDefault();

                return result;
            }

            return new FuelItem();
        }

        public async Task<ResultWeatherDto> GetWeatherAsync(string cityName)
        {
            ResultWeatherDto resultWeatherDto;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://open-weather13.p.rapidapi.com/city?city={cityName}&lang=TR"),
                Headers =
                {
                    { "x-rapidapi-key", $"{_weatherKey}" },
                    { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = System.Text.Json.JsonSerializer.Deserialize<Rootobject>(body);
                double tempInFahrenheit = result.main.temp;
                double tempInCelsius = (tempInFahrenheit - 32) / 1.8;
                resultWeatherDto = new ResultWeatherDto
                {
                    City = result.name,
                    Country = result.sys?.country,
                    Temp = (int)Math.Round(tempInCelsius),
                    Description = result.weather[0].description,
                    Humidity = result.main.humidity,
                    WindSpeed = result.wind.speed,
                    UvIndex = "Mod",
                    Icon = result.weather[0].icon
                };
            }
            return resultWeatherDto;
        }

        public async Task<HotelDetailDataDto?> GetHotelDetailAsync(int hotelId, string checkin, string checkout)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id={hotelId}&arrival_date={checkin}&departure_date={checkout}&adults=1&room_qty=1&languagecode=en-us&currency_code=EUR"),
                Headers =
                {
                    { "x-rapidapi-key", _hotelKey },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                Debug.WriteLine("------------------ JSON START ------------------");
                Debug.WriteLine(body);
                Debug.WriteLine("------------------ JSON END ------------------");

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = System.Text.Json.JsonSerializer.Deserialize<ResultHotelDetailDto>(body, options);

                return result?.Data;
            }
        }

        public async Task<ViewFinanceDto> GetFinanceAsync()
        {
            ViewFinanceDto result;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://exchangerate-api.p.rapidapi.com/rapid/latest/TRY"),
                Headers =
                {
                    { "x-rapidapi-key", $"{_financeKey}" },
                    { "x-rapidapi-host", "exchangerate-api.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseJson = System.Text.Json.JsonSerializer.Deserialize<ResultCurrencyDto>(body);
                result = new ViewFinanceDto
                {
                    UsdToTry = 1 / responseJson.Rates["USD"],
                    EurToTry = 1 / responseJson.Rates["EUR"],
                    GbpToTry = 1 / responseJson.Rates["GBP"],
                    LastUpdate = responseJson.LastUpdateUtc
                };
            }
            return result;
        }
    }
}
