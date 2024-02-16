using DoctorService.API.Data.Repositories;
using DoctorService.API.Interfaces.Repositories;

namespace DoctorService.API.DependencyInjection;
public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IDoctorAttendantRepository, DoctorAttendantRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();
        services.AddScoped<ISpecialityRepository, SpecialityRepository>();
    }
}
