using DoctorService.API.Data.DatabaseContexts;
using DoctorService.API.Factories;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString());
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });

        services.AddSettingsDependencyInjection();
        services.AddFilterDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddValidatorsDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
