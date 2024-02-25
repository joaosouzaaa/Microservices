using AppointmentService.API.Interfaces.Services;
using AppointmentService.API.Services;

namespace AppointmentService.API.DependencyInjection;
public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentTimeService, AppointmentTimeService>();
    }
}
