namespace DeluxeHotel.Services.GeminiServices
{
    public interface IGeminiService
    {
        Task<string> GetHistoricalRouteHtml(string prompt);
    }
}
