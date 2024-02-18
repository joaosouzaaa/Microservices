using PatientService.API.Interfaces.Services;
using PatientService.API.Services;

namespace PatientService.API.DependencyInjection;
public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IPatientClientService, PatientClientService>();
    }
}
