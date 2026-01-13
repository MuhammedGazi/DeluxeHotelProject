namespace DeluxeHotel.DTOs.MealDto;

public class MealDBResponse { public List<MealDetail> meals { get; set; } }
public class MealDetail
{
    public string strMeal { get; set; }
    public string strCategory { get; set; }
    public string strArea { get; set; }
    public string strInstructions { get; set; }
    public string strMealThumb { get; set; }
}

