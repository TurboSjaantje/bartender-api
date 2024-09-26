using bartender_api.Data;
using bartender_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bartender_api.Controllers
{
    [Route("api/Drinklist")]
    [ApiController]
    public class DrinkListController : ControllerBase
    {
        private readonly BartenderApiDbcontext _context;
        private readonly IConfiguration _configuration;

        public DrinkListController(BartenderApiDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult GetDrinkList()
        {
            try
            {
                var config = _context.Configuration.FirstOrDefault();
                var Drinks = _context.Drinks.ToList();
                var PossibleDrinkser = _context.MocktailCombinations
                                                .Include(x => x.Drinks)
                                                .ThenInclude(x => x.Drink)
                                                .AsEnumerable()
                                                .ToList();
                var PossibleDrinks = PossibleDrinkser
                                        .Where(x => CheckDrink(x, config))
                                        .ToList();

                var response = new
                {
                    drinks = PossibleDrinks.Select(x => new
                    {
                        name = x.Name,
                        ingredients = x.Drinks.Select(y => new
                        {
                            name = GetDrinkBottle(y.Drink, config),
                            volume = y.Percentage * 2
                        })
                    })
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }

        }


        private static bool CheckDrink(MocktailCombination mocktail, Configuration config)
        {
            var mocktailDrinks = mocktail.Drinks.ToList();
            List<Drink> configDrinks = new([config.Drink1, config.Drink2, config.Drink3, config.Drink4, config.Drink5, config.Drink6]);

            foreach (var drink in mocktailDrinks)
            {
                var drink2 = drink.Drink;

                if (!configDrinks.Contains(drink2))
                {
                    return false;
                }
                else
                {
                    if (drink2.Volume <= 100.0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static string GetDrinkBottle(Drink drink, Configuration configuration)
        {
            if (drink.Id == configuration.Drink1.Id) return "Bottle1"; 
            if (drink.Id == configuration.Drink2.Id) return "Bottle2"; 
            if (drink.Id == configuration.Drink3.Id) return "Bottle3"; 
            if (drink.Id == configuration.Drink4.Id) return "Bottle4"; 
            if (drink.Id == configuration.Drink5.Id) return "Bottle5"; 
            if (drink.Id == configuration.Drink6.Id) return "Bottle6"; 
            return "No Bottle";
        }
    }
}
