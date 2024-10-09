using bartender_api.Data;
using bartender_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bartender_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly BartenderApiDbcontext _context;

        public ConfigurationController(BartenderApiDbcontext context)
        {
            _context = context;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<Configuration>> GetConfiguration()
        {
            return _context.Configuration
                .Include(x => x.Drink1)
                .Include(x => x.Drink2)
                .Include(x => x.Drink3)
                .Include(x => x.Drink4)
                .Include(x => x.Drink5)
                .Include(x => x.Drink6)
                .FirstOrDefault();
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateConfiguration(PostConfig postConfig)
        {
            // use bottle id's to get drink id's
            var configuration = _context.Configuration.FirstOrDefault();
            configuration.Drink1Id = _context.Drinks.FirstOrDefault(x => x.Id == postConfig.Bottle1Id).Id;
            configuration.Drink2Id = _context.Drinks.FirstOrDefault(x => x.Id == postConfig.Bottle2Id).Id;
            configuration.Drink3Id = _context.Drinks.FirstOrDefault(x => x.Id == postConfig.Bottle3Id).Id;
            configuration.Drink4Id = _context.Drinks.FirstOrDefault(x => x.Id == postConfig.Bottle4Id).Id;
            configuration.Drink5Id = _context.Drinks.FirstOrDefault(x => x.Id == postConfig.Bottle5Id).Id;
            configuration.Drink6Id = _context.Drinks.FirstOrDefault(x => x.Id == postConfig.Bottle6Id).Id;

            _context.Entry(configuration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok(configuration);
        }

        // update making drink
        [HttpPut("makingDrink"), Authorize]
        public async Task<IActionResult> UpdateMakingDrink(bool makingDrink)
        {
            var configuration = _context.Configuration.FirstOrDefault();
            configuration.makingDrink = makingDrink;

            _context.Entry(configuration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok(configuration);
        }
    }

    public class PostConfig
    {
        public int Bottle1Id { get; set; }
        public int Bottle2Id { get; set; }
        public int Bottle3Id { get; set; }
        public int Bottle4Id { get; set; }
        public int Bottle5Id { get; set; }
        public int Bottle6Id { get; set; }
    }
}
