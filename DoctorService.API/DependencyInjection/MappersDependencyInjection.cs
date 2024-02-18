using DoctorService.API.Interfaces.Mappers;
using DoctorService.API.Mappers;

namespace DoctorService.API.DependencyInjection;
public static class MappersDependencyInjection
{
    public static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICertificationMapper, CertificationMapper>();
        services.AddScoped<IDoctorAttendantMapper, DoctorAttendantMapper>();
        services.AddScoped<IScheduleMapper, ScheduleMapper>();
        services.AddScoped<ISpecialityMapper, SpecialityMapper>();
    }
}
