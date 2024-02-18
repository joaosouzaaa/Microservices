using PatientService.API.Constants;
using PatientService.API.Options;

namespace PatientService.API.DependencyInjection;
public static class OptionsDependencyInjection
{
    public static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailCredentialsOptions>(options => configuration.GetSection(OptionsConstants.EmailCredentialsSection).Bind(options));
    }
}
