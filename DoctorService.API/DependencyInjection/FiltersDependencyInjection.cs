using DoctorService.API.Filters;

namespace DoctorService.API.DependencyInjection;

public static class FiltersDependencyInjection
{
    public static void AddFilterDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<NotificationFilter>();
        services.AddMvc(options => options.Filters.AddService<NotificationFilter>());
    }
}
