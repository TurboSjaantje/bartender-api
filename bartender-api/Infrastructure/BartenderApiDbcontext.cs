using bartender_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bartender_api.Infrastructure
{
    public class BartenderApiDbcontext : DbContext
    {
        public BartenderApiDbcontext(DbContextOptions<BartenderApiDbcontext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
