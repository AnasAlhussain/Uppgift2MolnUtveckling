using Microsoft.EntityFrameworkCore;

namespace Uppgift2MolnUtveckling.Models
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions options):base(options)
        {
            
        }

       public DbSet<Car> DbSet { get; set; }
    }
}
