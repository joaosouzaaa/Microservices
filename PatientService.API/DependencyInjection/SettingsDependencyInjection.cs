using PatientService.API.Interfaces.Settings;
using PatientService.API.Settings.NotificationSettings;

namespace PatientService.API.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
    }
}
