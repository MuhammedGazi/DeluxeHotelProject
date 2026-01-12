namespace DeluxeHotel.DTOs.OilDto
{
    public class FuelRoot
    {
        public List<FuelItem> data { get; set; }
    }

    public class FuelItem
    {
        public string Kursunsuz_95_TL_lt { get; set; } 
        public string Motorin_TL_lt { get; set; }     
        public string Otogaz_TL_lt { get; set; }     
        public string Ilce_Adi { get; set; }
    }
}
