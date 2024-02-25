using DoctorService.API.Constants;
using DoctorService.API.Options;

namespace DoctorService.API.DependencyInjection;
public static class OptionsDependencyInjection
{
    public static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMQCredentialsOptions>(options => configuration.GetSection(OptionsConstants.RabbitMQCredentialsSection).Bind(options));
    }
}
