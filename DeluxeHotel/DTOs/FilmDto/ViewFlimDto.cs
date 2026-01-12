namespace DeluxeHotel.DTOs.FilmDto
{
    public class ViewFlimDto
    {
        public string url { get; set; }
        public string originalTitle { get; set; }
        public Thumbnail[] thumbnails { get; set; }
        public string trailer { get; set; }
        public float? averageRating { get; set; }
    }
}
