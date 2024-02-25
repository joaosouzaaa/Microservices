using AppointmentService.API.Constants;
using AppointmentService.API.Options;

namespace AppointmentService.API.DependencyInjection;
public static class OptionsDependencyInjection
{
    public static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMQCredentialsOptions>(options => configuration.GetSection(OptionsConstants.RabbitMQCredentialsSection).Bind(options));
    }
}
