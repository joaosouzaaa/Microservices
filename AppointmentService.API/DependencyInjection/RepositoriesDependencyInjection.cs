using AppointmentService.API.Data.Repositories;
using AppointmentService.API.Interfaces.Repositories;

namespace AppointmentService.API.DependencyInjection;
public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentTimeRepository, AppointmentTimeRepository>();
    }
}
