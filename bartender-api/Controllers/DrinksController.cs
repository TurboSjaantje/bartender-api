using bartender_api.Data;
using bartender_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bartender_api.Controllers
{

    [Route("api/Drinks")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly BartenderApiDbcontext _context;
        private readonly IConfiguration _configuration;

        public DrinksController(BartenderApiDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrinks()
        {
            return await _context.Drinks.ToListAsync();
        }

        [HttpGet, Authorize]
        [Route("{id}")]
        public async Task<ActionResult<Drink>> GetDrinkById(int id)
        {
            var drink = await _context.Drinks.FindAsync(id);

            if (drink == null)
            {
                return NotFound();
            }

            return drink;
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<Drink>> PostDrink(Drink drink)
        {
            _context.Drinks.Add(drink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrink", new { id = drink.Id }, drink);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            var drink = await _context.Drinks.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }

            var deletedDrink = _context.Drinks.FindAsync(id);

            _context.Drinks.Remove(drink);
            await _context.SaveChangesAsync();

            return Ok(deletedDrink);
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateDrink(int id, Drink drink)
        {
            if (id != drink.Id)
            {
                return BadRequest();
            }

            _context.Entry(drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            var updatedDrink = _context.Drinks.FindAsync(id);

            return Ok(updatedDrink);
        }
    }
}
