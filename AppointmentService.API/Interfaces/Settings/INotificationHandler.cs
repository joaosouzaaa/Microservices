using AppointmentService.API.Settings.NotificationSettings;

namespace AppointmentService.API.Interfaces.Settings;
public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(string key, string message);
}
