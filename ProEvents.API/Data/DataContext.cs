using Event.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Event.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Party> Parties { get; set; }
    }
}
