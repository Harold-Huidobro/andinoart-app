
namespace Andinoart_app.Domain.Models
{
    using System.Data.Entity;
    using Common.Models;

    public class DataContext : DbContext
    {

        public DbSet<Artisan> Artisans { get; set; }
        public DbSet<Product> Products { get; set; }

        public DataContext() : base("DefaultConnection")
        {

        }

    }
}
