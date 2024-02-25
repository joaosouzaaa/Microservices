using AppointmentService.API.Contracts;
using AppointmentService.API.DataTransferObjects.Appointment;
using AppointmentService.API.Entities;
using AppointmentService.API.Interfaces.Mappers;

namespace AppointmentService.API.Mappers;
public sealed class AppointmentTimeMapper : IAppointmentTimeMapper
{
    public AppointmentTime SaveToDomain(AppointmentTimeSave appointmentTimeSave) =>
        new()
        {
            DoctorAttendantId = appointmentTimeSave.DoctorAttendantId,
            PatientClientId = appointmentTimeSave.PatientClientId,
            Time = appointmentTimeSave.Time
        };

    public AppointmentTimeCreatedEvent DomainToTimeCreatedEvent(AppointmentTime appointmentTime) =>
        new(appointmentTime.Time,
            appointmentTime.DoctorAttendantId,
            appointmentTime.PatientClientId);
}
