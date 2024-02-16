using DoctorService.API.Interfaces.Settings;
using DoctorService.API.Settings.NotificationSettings;

namespace DoctorService.API.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
    }
}
