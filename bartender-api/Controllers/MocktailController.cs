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
            return await _context.MocktailCombinations.ToListAsync();
        }
    }
}
