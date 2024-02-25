using DoctorService.API.Consumers;

namespace DoctorService.API.DependencyInjection;
public static class ConsumersDependencyInjection
{
    public static void AddConsumersDependencyInjection(this IServiceCollection services)
    {
        services.AddHostedService<AppointmentCreatedConsumer>();
    }
}
