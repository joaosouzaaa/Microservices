using AppointmentService.API.Interfaces.Mappers;
using AppointmentService.API.Mappers;

namespace AppointmentService.API.DependencyInjection;
public static class MappersDependencyInjection
{
    public static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentTimeMapper, AppointmentTimeMapper>();
    }
}
