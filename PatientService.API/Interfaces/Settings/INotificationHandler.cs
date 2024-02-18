using PatientService.API.Settings.NotificationSettings;

namespace PatientService.API.Interfaces.Settings;
public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(string key, string message);
}
