using AppointmentService.API.Interfaces.Publishers;
using AppointmentService.API.Publishers;

namespace AppointmentService.API.DependencyInjection;
public static class PublishersDependencyInjection
{
    public static void AddPublishersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentPublisher, AppointmentPublisher>();
    }
}
