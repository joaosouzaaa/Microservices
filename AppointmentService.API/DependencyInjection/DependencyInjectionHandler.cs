using AppointmentService.API.Data.DatabaseContexts;
using AppointmentService.API.Factories;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.API.DependencyInjection;

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
        services.AddPublishersDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddValidatorsDependencyInjection();
    }
}
