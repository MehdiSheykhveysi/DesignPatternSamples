using Microsoft.EntityFrameworkCore;
using ProxyPattern.Domain;

namespace ProxyPattern.Infrastructure.Data
{
    public class DesignPatternContext : DbContext
    {
        public DesignPatternContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
