using bartender_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bartender_api.Data
{
    public class BartenderApiDbcontext : DbContext
    {
        public BartenderApiDbcontext(DbContextOptions<BartenderApiDbcontext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<MocktailCombination> MocktailCombinations { get; set; }
        public DbSet<DrinkWithPercentage> DrinkWithPercentages { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
    }
}