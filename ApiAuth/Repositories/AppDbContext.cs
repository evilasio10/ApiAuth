using ApiAuth.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAuth.Repositories
{
    public class AppDbContext :DbContext
    {
        public AppDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Settings.ConnectionString);
            }
        }
        
        public DbSet<Usuario> Usuario { get; set; }
    }
}
