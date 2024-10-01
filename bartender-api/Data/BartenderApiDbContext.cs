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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Configuration data
            modelBuilder.Entity<Configuration>().HasData(
                new Configuration
                {
                    Id = 1,  // ID for the configuration record
                    Drink1Id = 1,  // Appelsap
                    Drink2Id = 2,  // Sprite / 7Up
                    Drink3Id = 3,  // Sinaasappelsap
                    Drink4Id = 4,  // Cola
                    Drink5Id = 5,  // Fanta
                    Drink6Id = 6   // Bruisend water
                }
            );

            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.Drink1)
                .WithMany()
                .HasForeignKey(c => c.Drink1Id)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.Drink2)
                .WithMany()
                .HasForeignKey(c => c.Drink2Id)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.Drink3)
                .WithMany()
                .HasForeignKey(c => c.Drink3Id)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.Drink4)
                .WithMany()
                .HasForeignKey(c => c.Drink4Id)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.Drink5)
                .WithMany()
                .HasForeignKey(c => c.Drink5Id)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete

            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.Drink6)
                .WithMany()
                .HasForeignKey(c => c.Drink6Id)
                .OnDelete(DeleteBehavior.NoAction);  // Disable cascade delete



            // Seed Drink data
            modelBuilder.Entity<Drink>().HasData(
                new Drink { Id = 1, Name = "Appelsap", Volume = 250 },
                new Drink { Id = 2, Name = "Sprite / 7Up", Volume = 200 },
                new Drink { Id = 3, Name = "Sinaasappelsap", Volume = 250 },
                new Drink { Id = 4, Name = "Cola", Volume = 330 },
                new Drink { Id = 5, Name = "Fanta", Volume = 250 },
                new Drink { Id = 6, Name = "Bruisend water", Volume = 500 },
                new Drink { Id = 7, Name = "Ice tea perzik", Volume = 330 },
                new Drink { Id = 8, Name = "Ginger ale", Volume = 200 }
            );

            // Seed MocktailCombination data
            modelBuilder.Entity<MocktailCombination>().HasData(
                new MocktailCombination { Id = 1, Name = "Crisp Fizz" },
                new MocktailCombination { Id = 2, Name = "Citrus Cola" },
                new MocktailCombination { Id = 3, Name = "Fruity Splash" },
                new MocktailCombination { Id = 4, Name = "Peach Fizz" },
                new MocktailCombination { Id = 5, Name = "Apple Fizz" },
                new MocktailCombination { Id = 6, Name = "Tropical Fizz" },
                new MocktailCombination { Id = 7, Name = "Citrus Delight" },
                new MocktailCombination { Id = 8, Name = "Refreshing Berry" },
                new MocktailCombination { Id = 9, Name = "Apple Citrus Sparkle" },
                new MocktailCombination { Id = 10, Name = "Cola Fanta Mix" },
                new MocktailCombination { Id = 11, Name = "Citrus Berry Splash" },
                new MocktailCombination { Id = 12, Name = "Sparkling Citrus Punch" },
                new MocktailCombination { Id = 13, Name = "Apple Fanta Delight" },
                new MocktailCombination { Id = 14, Name = "Fruity Ginger Mix" },
                new MocktailCombination { Id = 15, Name = "Tropical Twist" },
                new MocktailCombination { Id = 16, Name = "Crisp Refreshment" },
                new MocktailCombination { Id = 17, Name = "Citrus Punch" },
                new MocktailCombination { Id = 18, Name = "Fruity Delight" },
                new MocktailCombination { Id = 19, Name = "Sparkling Fruit Medley" },
                new MocktailCombination { Id = 20, Name = "Citrus Melange" }
            );

            // Seed DrinkWithPercentage data
            modelBuilder.Entity<DrinkWithPercentage>().HasData(
                // Crisp Fizz
                new DrinkWithPercentage { Id = 1, DrinkId = 1, Percentage = 60f, MocktailCombinationId = 1 },  // Appelsap
                new DrinkWithPercentage { Id = 2, DrinkId = 2, Percentage = 40f, MocktailCombinationId = 1 },  // Sprite / 7Up

                // Citrus Cola
                new DrinkWithPercentage { Id = 3, DrinkId = 3, Percentage = 50f, MocktailCombinationId = 2 },  // Sinaasappelsap
                new DrinkWithPercentage { Id = 4, DrinkId = 4, Percentage = 50f, MocktailCombinationId = 2 },  // Cola

                // Fruity Splash
                new DrinkWithPercentage { Id = 5, DrinkId = 5, Percentage = 70f, MocktailCombinationId = 3 },  // Fanta
                new DrinkWithPercentage { Id = 6, DrinkId = 6, Percentage = 30f, MocktailCombinationId = 3 },  // Bruisend water

                // Peach Fizz
                new DrinkWithPercentage { Id = 7, DrinkId = 7, Percentage = 60f, MocktailCombinationId = 4 },  // Ice tea perzik
                new DrinkWithPercentage { Id = 8, DrinkId = 8, Percentage = 40f, MocktailCombinationId = 4 },  // Ginger ale

                // Apple Fizz
                new DrinkWithPercentage { Id = 9, DrinkId = 1, Percentage = 50f, MocktailCombinationId = 5 },  // Appelsap
                new DrinkWithPercentage { Id = 10, DrinkId = 6, Percentage = 50f, MocktailCombinationId = 5 }, // Bruisend water

                // Tropical Fizz (3 drinks)
                new DrinkWithPercentage { Id = 11, DrinkId = 5, Percentage = 40f, MocktailCombinationId = 6 }, // Fanta
                new DrinkWithPercentage { Id = 12, DrinkId = 1, Percentage = 30f, MocktailCombinationId = 6 }, // Appelsap
                new DrinkWithPercentage { Id = 13, DrinkId = 2, Percentage = 30f, MocktailCombinationId = 6 }, // Sprite / 7Up

                // Citrus Delight (3 drinks)
                new DrinkWithPercentage { Id = 14, DrinkId = 3, Percentage = 40f, MocktailCombinationId = 7 }, // Sinaasappelsap
                new DrinkWithPercentage { Id = 15, DrinkId = 8, Percentage = 30f, MocktailCombinationId = 7 }, // Ginger ale
                new DrinkWithPercentage { Id = 16, DrinkId = 6, Percentage = 30f, MocktailCombinationId = 7 }, // Bruisend water

                // Refreshing Berry (3 drinks)
                new DrinkWithPercentage { Id = 17, DrinkId = 7, Percentage = 40f, MocktailCombinationId = 8 }, // Ice tea perzik
                new DrinkWithPercentage { Id = 18, DrinkId = 4, Percentage = 30f, MocktailCombinationId = 8 }, // Cola
                new DrinkWithPercentage { Id = 19, DrinkId = 2, Percentage = 30f, MocktailCombinationId = 8 }, // Sprite / 7Up

                // Apple Citrus Sparkle (3 drinks)
                new DrinkWithPercentage { Id = 20, DrinkId = 1, Percentage = 40f, MocktailCombinationId = 9 }, // Appelsap
                new DrinkWithPercentage { Id = 21, DrinkId = 3, Percentage = 30f, MocktailCombinationId = 9 }, // Sinaasappelsap
                new DrinkWithPercentage { Id = 22, DrinkId = 8, Percentage = 30f, MocktailCombinationId = 9 }, // Ginger ale

                // Cola Fanta Mix (3 drinks)
                new DrinkWithPercentage { Id = 23, DrinkId = 4, Percentage = 50f, MocktailCombinationId = 10 }, // Cola
                new DrinkWithPercentage { Id = 24, DrinkId = 5, Percentage = 50f, MocktailCombinationId = 10 }, // Fanta
                new DrinkWithPercentage { Id = 25, DrinkId = 6, Percentage = 20f, MocktailCombinationId = 10 }, // Bruisend water

                // Citrus Berry Splash (4 drinks)
                new DrinkWithPercentage { Id = 26, DrinkId = 3, Percentage = 30f, MocktailCombinationId = 11 }, // Sinaasappelsap
                new DrinkWithPercentage { Id = 27, DrinkId = 1, Percentage = 30f, MocktailCombinationId = 11 }, // Appelsap
                new DrinkWithPercentage { Id = 28, DrinkId = 7, Percentage = 20f, MocktailCombinationId = 11 }, // Ice tea perzik
                new DrinkWithPercentage { Id = 29, DrinkId = 2, Percentage = 20f, MocktailCombinationId = 11 }, // Sprite / 7Up

                // Sparkling Citrus Punch (4 drinks)
                new DrinkWithPercentage { Id = 30, DrinkId = 2, Percentage = 30f, MocktailCombinationId = 12 }, // Sprite / 7Up
                new DrinkWithPercentage { Id = 31, DrinkId = 8, Percentage = 30f, MocktailCombinationId = 12 }, // Ginger ale
                new DrinkWithPercentage { Id = 32, DrinkId = 5, Percentage = 20f, MocktailCombinationId = 12 }, // Fanta
                new DrinkWithPercentage { Id = 33, DrinkId = 6, Percentage = 20f, MocktailCombinationId = 12 }, // Bruisend water

                // Apple Fanta Delight (4 drinks)
                new DrinkWithPercentage { Id = 34, DrinkId = 1, Percentage = 30f, MocktailCombinationId = 13 }, // Appelsap
                new DrinkWithPercentage { Id = 35, DrinkId = 5, Percentage = 30f, MocktailCombinationId = 13 }, // Fanta
                new DrinkWithPercentage { Id = 36, DrinkId = 4, Percentage = 20f, MocktailCombinationId = 13 }, // Cola
                new DrinkWithPercentage { Id = 37, DrinkId = 6, Percentage = 20f, MocktailCombinationId = 13 }, // Bruisend water

                // Fruity Ginger Mix (4 drinks)
                new DrinkWithPercentage { Id = 38, DrinkId = 8, Percentage = 40f, MocktailCombinationId = 14 }, // Ginger ale
                new DrinkWithPercentage { Id = 39, DrinkId = 7, Percentage = 30f, MocktailCombinationId = 14 }, // Ice tea perzik
                new DrinkWithPercentage { Id = 40, DrinkId = 1, Percentage = 20f, MocktailCombinationId = 14 }, // Appelsap
                new DrinkWithPercentage { Id = 41, DrinkId = 2, Percentage = 10f, MocktailCombinationId = 14 }, // Sprite / 7Up

                // Tropical Twist (4 drinks)
                new DrinkWithPercentage { Id = 42, DrinkId = 5, Percentage = 30f, MocktailCombinationId = 15 }, // Fanta
                new DrinkWithPercentage { Id = 43, DrinkId = 7, Percentage = 30f, MocktailCombinationId = 15 }, // Ice tea perzik
                new DrinkWithPercentage { Id = 44, DrinkId = 4, Percentage = 20f, MocktailCombinationId = 15 }, // Cola
                new DrinkWithPercentage { Id = 45, DrinkId = 6, Percentage = 20f, MocktailCombinationId = 15 }, // Bruisend water

                // Crisp Refreshment (5 drinks)
                new DrinkWithPercentage { Id = 46, DrinkId = 2, Percentage = 25f, MocktailCombinationId = 16 }, // Sprite / 7Up
                new DrinkWithPercentage { Id = 47, DrinkId = 1, Percentage = 25f, MocktailCombinationId = 16 }, // Appelsap
                new DrinkWithPercentage { Id = 48, DrinkId = 5, Percentage = 20f, MocktailCombinationId = 16 }, // Fanta
                new DrinkWithPercentage { Id = 49, DrinkId = 8, Percentage = 20f, MocktailCombinationId = 16 }, // Ginger ale
                new DrinkWithPercentage { Id = 50, DrinkId = 6, Percentage = 10f, MocktailCombinationId = 16 }, // Bruisend water

                // Citrus Punch (5 drinks)
                new DrinkWithPercentage { Id = 51, DrinkId = 3, Percentage = 25f, MocktailCombinationId = 17 }, // Sinaasappelsap
                new DrinkWithPercentage { Id = 52, DrinkId = 1, Percentage = 25f, MocktailCombinationId = 17 }, // Appelsap
                new DrinkWithPercentage { Id = 53, DrinkId = 7, Percentage = 20f, MocktailCombinationId = 17 }, // Ice tea perzik
                new DrinkWithPercentage { Id = 54, DrinkId = 4, Percentage = 20f, MocktailCombinationId = 17 }, // Cola
                new DrinkWithPercentage { Id = 55, DrinkId = 8, Percentage = 10f, MocktailCombinationId = 17 }, // Ginger ale

                // Fruity Delight (5 drinks)
                new DrinkWithPercentage { Id = 56, DrinkId = 5, Percentage = 25f, MocktailCombinationId = 18 }, // Fanta
                new DrinkWithPercentage { Id = 57, DrinkId = 2, Percentage = 25f, MocktailCombinationId = 18 }, // Sprite / 7Up
                new DrinkWithPercentage { Id = 58, DrinkId = 7, Percentage = 20f, MocktailCombinationId = 18 }, // Ice tea perzik
                new DrinkWithPercentage { Id = 59, DrinkId = 1, Percentage = 20f, MocktailCombinationId = 18 }, // Appelsap
                new DrinkWithPercentage { Id = 60, DrinkId = 6, Percentage = 10f, MocktailCombinationId = 18 }, // Bruisend water

                // Sparkling Fruit Medley (6 drinks)
                new DrinkWithPercentage { Id = 61, DrinkId = 2, Percentage = 20f, MocktailCombinationId = 19 }, // Sprite / 7Up
                new DrinkWithPercentage { Id = 62, DrinkId = 5, Percentage = 20f, MocktailCombinationId = 19 }, // Fanta
                new DrinkWithPercentage { Id = 63, DrinkId = 4, Percentage = 20f, MocktailCombinationId = 19 }, // Cola
                new DrinkWithPercentage { Id = 64, DrinkId = 1, Percentage = 20f, MocktailCombinationId = 19 }, // Appelsap
                new DrinkWithPercentage { Id = 65, DrinkId = 8, Percentage = 10f, MocktailCombinationId = 19 }, // Ginger ale
                new DrinkWithPercentage { Id = 66, DrinkId = 7, Percentage = 10f, MocktailCombinationId = 19 }, // Ice tea perzik

                // Citrus Melange (6 drinks)
                new DrinkWithPercentage { Id = 67, DrinkId = 3, Percentage = 20f, MocktailCombinationId = 20 }, // Sinaasappelsap
                new DrinkWithPercentage { Id = 68, DrinkId = 1, Percentage = 20f, MocktailCombinationId = 20 }, // Appelsap
                new DrinkWithPercentage { Id = 69, DrinkId = 2, Percentage = 20f, MocktailCombinationId = 20 }, // Sprite / 7Up
                new DrinkWithPercentage { Id = 70, DrinkId = 5, Percentage = 20f, MocktailCombinationId = 20 }, // Fanta
                new DrinkWithPercentage { Id = 71, DrinkId = 8, Percentage = 10f, MocktailCombinationId = 20 }, // Ginger ale
                new DrinkWithPercentage { Id = 72, DrinkId = 6, Percentage = 10f, MocktailCombinationId = 20 }  // Bruisend water
            );
        }
    }
}
