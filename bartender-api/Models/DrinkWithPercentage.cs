namespace bartender_api.Models
{
    public class DrinkWithPercentage
    {
        public int Id { get; set; } 
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public float Percentage { get; set; }
        public int MocktailCombinationId { get; set; }
        public MocktailCombination MocktailCombination { get; set; }
    }
}
