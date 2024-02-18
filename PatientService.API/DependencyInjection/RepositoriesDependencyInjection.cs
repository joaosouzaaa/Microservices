using PatientService.API.Data.Repositories;
using PatientService.API.Interfaces.Repositories;

namespace PatientService.API.DependencyInjection;
public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPatientClientRepository, PatientClientRepository>();
        services.AddScoped<IPatientClientRepositoryFacade, PatientClientRepository>();
    }
}
