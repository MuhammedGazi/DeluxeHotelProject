using System.Text.Json.Serialization;

namespace DeluxeHotel.DTOs.FinanceDto;

public record ResultCurrencyDto(
    [property: JsonPropertyName("result")] string Result,
    [property: JsonPropertyName("base_code")] string BaseCode,
    [property: JsonPropertyName("rates")] Dictionary<string, decimal> Rates,
    [property: JsonPropertyName("time_last_update_utc")] string LastUpdateUtc
);
