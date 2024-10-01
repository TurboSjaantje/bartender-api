namespace bartender_api.Models
{
    public class Configuration
    {
        public int Id { get; set; } 

        public int Drink1Id { get; set; }
        public Drink? Drink1 { get; set; }

        public int Drink2Id { get; set; }
        public Drink? Drink2 { get; set; }

        public int Drink3Id { get; set; }
        public Drink? Drink3 { get; set; }

        public int Drink4Id { get; set; }
        public Drink? Drink4 { get; set; }

        public int Drink5Id { get; set; }
        public Drink? Drink5 { get; set; }

        public int Drink6Id { get; set; }
        public Drink? Drink6 { get; set; }
    }
}
