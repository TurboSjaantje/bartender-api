using bartender_api.Data;
using bartender_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bartender_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MocktailController : Controller
    {
        private readonly BartenderApiDbcontext _context;
        private readonly IConfiguration _configuration;

        public MocktailController(BartenderApiDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<MocktailCombination>>> GetMocktailCombinations()
        {
            return await _context.MocktailCombinations
                                    .Include(x => x.Drinks)
                                    .ThenInclude(y => y.Drink)
                                    .ToListAsync();
        }

        [HttpGet, Authorize]
        [Route("{id}")]
        public async Task<ActionResult<MocktailCombination>> GetMocktailCombinationById(int id)
        {
            var mocktail = await _context.MocktailCombinations.FindAsync(id);

            if (mocktail == null)
            {
                return NotFound();
            }

            return mocktail;
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<MocktailCombination>> PostMocktailCombination(MocktailCombinationInput mocktail)
        {
            var newMocktailCombination = new MocktailCombination
            {
                Name = mocktail.Name,
                Drinks = new List<DrinkWithPercentage>()
            };

            foreach (var drinkInput in mocktail.Drinks)
            {
                var drink = await _context.Drinks.FindAsync(drinkInput.Id);

                if (drink == null) return BadRequest($"Drink with ID {drinkInput.Id} not found");

                var drinkWithPercentage = new DrinkWithPercentage
                {
                    Drink = drink,
                    Percentage = drinkInput.Percentage
                };

                newMocktailCombination.Drinks.Add(drinkWithPercentage);
            }

            _context.MocktailCombinations.Add(newMocktailCombination);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMocktailCombination", new { id = newMocktailCombination.Id }, newMocktailCombination);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteMocktailCombination(int id)
        {
            var mocktail = await _context.MocktailCombinations.FindAsync(id);
            if (mocktail == null)
            {
                return NotFound();
            }

            var deletedMocktail = _context.MocktailCombinations.FindAsync(id);

            _context.MocktailCombinations.Remove(mocktail);
            await _context.SaveChangesAsync();

            return Ok(deletedMocktail);
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateMocktailCombination(int id, MocktailCombinationInput mocktail)
        {
            var mocktailCombination = await _context.MocktailCombinations.FindAsync(id);

            if (mocktailCombination == null)
            {
                return NotFound();
            }

            mocktailCombination.Name = mocktail.Name;

            foreach (var drinkInput in mocktail.Drinks)
            {
                var drink = await _context.Drinks.FindAsync(drinkInput.Id);

                if (drink == null) return BadRequest($"Drink with ID {drinkInput.Id} not found");

                var drinkWithPercentage = mocktailCombination.Drinks.FirstOrDefault(x => x.Drink.Id == drinkInput.Id);

                if (drinkWithPercentage == null)
                {
                    drinkWithPercentage = new DrinkWithPercentage
                    {
                        Drink = drink,
                        Percentage = drinkInput.Percentage
                    };
                    mocktailCombination.Drinks.Add(drinkWithPercentage);
                }
                else
                {
                    drinkWithPercentage.Percentage = drinkInput.Percentage;
                }
            }

            await _context.SaveChangesAsync();
            return Ok(mocktailCombination);
        }

        public class MocktailCombinationInput
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<DrinkWithPercentageInput> Drinks { get; set; }

            public MocktailCombinationInput(int id, string name, List<DrinkWithPercentageInput> drinks)
            {
                this.Id = id;
                this.Name = name;
                this.Drinks = drinks;
            }
        }


        public class DrinkWithPercentageInput
        {
            public int Id { get; set; }
            public float Percentage { get; set; }

            public DrinkWithPercentageInput(int id, float percentage)
            {
                this.Id = id;
                this.Percentage = percentage;
            }
        }

    }
}
