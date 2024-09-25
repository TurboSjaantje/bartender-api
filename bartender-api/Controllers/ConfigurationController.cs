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
            return _context.Configuration.FirstOrDefault();
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateConfiguration(Configuration configuration)
        {
            var id = _context.Configuration.FirstOrDefault().Id;
            configuration.Id = id;

            _context.Entry(configuration).State = EntityState.Modified;

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
