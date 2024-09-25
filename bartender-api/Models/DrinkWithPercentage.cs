namespace bartender_api.Models
{
    public class DrinkWithPercentage
    {
        public int Id { get; set; } 
        public Drink Drink { get; set; }
        public float Percentage { get; set; }
        public List<MocktailCombination> MocktailCombinations { get; set; }
    }
}
