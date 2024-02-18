using DoctorService.API.Interfaces.Services;
using DoctorService.API.Services;

namespace DoctorService.API.DependencyInjection;
public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IDoctorAttendantService, DoctorAttendantService>();
        services.AddScoped<IScheduleService, ScheduleService>();

        services.AddScoped<ISpecialityService, SpecialityService>();
        services.AddScoped<ISpecialityServiceFacade, SpecialityService>();
    }
}
