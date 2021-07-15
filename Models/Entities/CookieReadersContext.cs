using Microsoft.EntityFrameworkCore;

namespace CookieReaders.Models.Entities
{
    public class CookieReadersContext : DbContext
    {
        public CookieReadersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CookieUser> Users { get; set; }
    }
}