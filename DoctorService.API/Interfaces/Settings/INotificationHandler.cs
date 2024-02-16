using DoctorService.API.Settings.NotificationSettings;

namespace DoctorService.API.Interfaces.Settings;
public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(string key, string message);
}
