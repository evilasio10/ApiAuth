using ApiAuth.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiAuth.Service
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                 .GetService<AppDbContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}

