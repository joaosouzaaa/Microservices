using AppointmentService.API.DataTransferObjects.Appointment;

namespace AppointmentService.API.Interfaces.Services;
public interface IAppointmentTimeService
{
    Task<bool> AddAsync(AppointmentTimeSave appointmentTimeSave);
}
