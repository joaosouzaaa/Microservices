using PatientService.API.Consumers;

namespace PatientService.API.DependencyInjection;
public static class ConsumersDependencyInjection
{
    public static void AddConsumersDependencyInjection(this IServiceCollection services)
    {
        services.AddHostedService<AppointmentCreatedConsumer>();
    }
}
