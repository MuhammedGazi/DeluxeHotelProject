using DeluxeHotel.DTOs.FilmDto;
using DeluxeHotel.DTOs.FinanceDto;
using DeluxeHotel.DTOs.HotelDto;
using DeluxeHotel.DTOs.MealDto;
using DeluxeHotel.DTOs.OilDto;
using DeluxeHotel.DTOs.WeatherDto;

namespace DeluxeHotel.Services.ApiServices
{
    public interface IApiService
    {
        Task<List<ViewFlimDto>> GetFlimAsync();
        Task<List<RequestHotelDto>> GetHotelAsync(string city, string checkIn, string checkOut);
        Task<HotelDetailDataDto?> GetHotelDetailAsync(int hotelId, string checkin, string checkout);
        Task<ViewMealDto> GetMealAsync();
        Task<ViewFinanceDto> GetFinanceAsync();
        Task<FuelItem> GetOilAsync(string city = "Ankara");
        Task<ResultWeatherDto> GetWeatherAsync(string cityName = "Ankara");
    }
}
