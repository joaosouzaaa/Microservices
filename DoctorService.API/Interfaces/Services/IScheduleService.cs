using DoctorService.API.Contracts;

namespace DoctorService.API.Interfaces.Services;
public interface IScheduleService
{
    Task AddAsync(AppointmentTimeCreatedEvent appointmentTimeCreatedEvent);
}
