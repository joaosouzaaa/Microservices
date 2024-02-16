using DoctorService.API.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.API.DependencyInjection;
public static class MigrationHandler
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            appDbContext.Database.Migrate();
        }
        catch
        {
            throw;
        }
    }
}
