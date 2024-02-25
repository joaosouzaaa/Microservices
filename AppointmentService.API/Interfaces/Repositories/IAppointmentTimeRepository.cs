using AppointmentService.API.Entities;

namespace AppointmentService.API.Interfaces.Repositories;
public interface IAppointmentTimeRepository
{
    Task<bool> AddAsync(AppointmentTime appointmentTime);
    Task<bool> ExistsByTimeAndDoctorAsync(int doctorAttendantId, DateTime time);
}
