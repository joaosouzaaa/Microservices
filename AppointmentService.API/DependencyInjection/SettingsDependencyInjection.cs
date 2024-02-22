using AppointmentService.API.Interfaces.Settings;
using AppointmentService.API.Settings.NotificationSettings;

namespace AppointmentService.API.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
    }
}
