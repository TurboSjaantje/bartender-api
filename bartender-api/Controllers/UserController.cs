using Microsoft.AspNetCore.Mvc;
using bartender_api.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using bartender_api.Data;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace bartender_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BartenderApiDbcontext _context;
        private readonly IConfiguration _configuration;

        public UsersController(BartenderApiDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/users (Protected Route - Requires Authorization)
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // DELETE: api/users/5 (Protected Route - Requires Authorization)
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var deletedUser = _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(deletedUser);
        }

        // UPDATE: api/users/5 (Protected Route - Requires Authorization)
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            var updatedUser = _context.Users.FindAsync(id);
            return Ok(updatedUser);
        }

        // POST: api/users/register (Register a New User)
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterModel model)
        {
            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                return BadRequest("Email is already taken.");
            }

            // In a real app, you should hash the password before storing it
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password // Store hashed password here
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        // POST: api/users/login (Authenticate the User and Generate JWT Token)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Check if user exists
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        // Helper method to generate JWT token
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}