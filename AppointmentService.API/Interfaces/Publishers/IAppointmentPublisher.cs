using AppointmentService.API.Contracts;

namespace AppointmentService.API.Interfaces.Publishers;
public interface IAppointmentPublisher
{
    void PublishAppointmentTimeCreatedMessage(AppointmentTimeCreatedEvent appointment);
}
