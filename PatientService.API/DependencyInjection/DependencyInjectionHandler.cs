using PatientService.API.Data.DatabaseContexts;
using PatientService.API.Factories;
using Microsoft.EntityFrameworkCore;

namespace PatientService.API.DependencyInjection;

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
        services.AddOptionsDependencyInjection(configuration);
        services.AddFilterDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddValidatorsDependencyInjection();
    }
}
