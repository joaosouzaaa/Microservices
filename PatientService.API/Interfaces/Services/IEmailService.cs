using PatientService.API.Contracts;

namespace PatientService.API.Interfaces.Services;
public interface IEmailService
{
    Task SendAppointmentEmailAsync(AppointmentTimeCreatedEvent appointmentTimeCreatedEvent);
}
