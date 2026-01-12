using System.Text.Json.Serialization;

namespace DeluxeHotel.DTOs.HotelDto;

public record LocationResponse([property: JsonPropertyName("data")] List<LocationData> Data);
public record LocationData([property: JsonPropertyName("dest_id")] string DestId);
