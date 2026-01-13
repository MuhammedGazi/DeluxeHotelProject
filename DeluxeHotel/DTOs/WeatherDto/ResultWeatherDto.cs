namespace DeluxeHotel.DTOs.WeatherDto
{
    public class ResultWeatherDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int Temp { get; set; }
        public string Description { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string UvIndex { get; set; }
        public string Icon { get; set; }
    }
}
