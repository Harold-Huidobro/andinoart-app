namespace Andinoart_app.Backend.Models
{
    using Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Andinoart_app.Common.Models.Artisan> Artisans { get; set; }
    }
}