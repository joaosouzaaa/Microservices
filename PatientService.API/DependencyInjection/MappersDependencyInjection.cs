using PatientService.API.Interfaces.Mappers;
using PatientService.API.Mappers;

namespace PatientService.API.DependencyInjection;
public static class MappersDependencyInjection
{
    public static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IContactInfoMapper, ContactInfoMapper>();
        services.AddScoped<IPatientClientMapper, PatientClientMapper>();
    }
}
