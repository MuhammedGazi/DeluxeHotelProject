using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeluxeHotel.DTOs.HotelDto;

public record ResultHotelDetailDto(
    [property: JsonPropertyName("status")] bool Status,
    [property: JsonPropertyName("message")] JsonElement Message,
    [property: JsonPropertyName("data")] HotelDetailDataDto? Data
);

public record HotelDetailDataDto(
    [property: JsonPropertyName("hotel_id")] int HotelId,
    [property: JsonPropertyName("hotel_name")] string HotelName,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("arrival_date")] string ArrivalDate,
    [property: JsonPropertyName("departure_date")] string DepartureDate,
    [property: JsonPropertyName("currency_code")] string CurrencyCode,
    [property: JsonPropertyName("available_rooms")] int AvailableRooms,
    [property: JsonPropertyName("max_rooms_in_reservation")] int MaxRoomsInReservation,
    [property: JsonPropertyName("review_nr")] int ReviewCount,
    [property: JsonPropertyName("facilities_block")] FacilitiesBlockDto? FacilitiesBlock,
    [property: JsonPropertyName("rooms")] Dictionary<string, RoomDetailDto>? Rooms,
    [property: JsonPropertyName("spoken_languages")] List<string>? SpokenLanguages,
    [property: JsonPropertyName("composite_price_breakdown")] PriceBreakdownDto? PriceBreakdown,
    [property: JsonPropertyName("sustainability")] SustainabilityDto? Sustainability
);

public record RoomDetailDto(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("photos")] List<PhotoDto>? Photos
);

public record PhotoDto([property: JsonPropertyName("url_max1280")] string Url);

public record FacilitiesBlockDto(
    [property: JsonPropertyName("facilities")] List<FacilityDto>? Facilities,
    [property: JsonPropertyName("name")] string Title
);

public record FacilityDto([property: JsonPropertyName("name")] string Name);

public record PriceBreakdownDto(
    [property: JsonPropertyName("all_inclusive_amount")] AmountDto? TotalAmount,
    [property: JsonPropertyName("gross_amount_per_night")] AmountDto? NightlyAmount
);

public record AmountDto(
    [property: JsonPropertyName("value")] double Value,
    [property: JsonPropertyName("currency")] string Currency
);

public record SustainabilityDto([property: JsonPropertyName("hotel_page")] SustainabilityInfo? Info);
public record SustainabilityInfo([property: JsonPropertyName("title")] string Title, [property: JsonPropertyName("description")] string Description);