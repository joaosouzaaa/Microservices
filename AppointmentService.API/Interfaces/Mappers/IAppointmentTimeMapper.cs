using AppointmentService.API.Contracts;
using AppointmentService.API.DataTransferObjects.Appointment;
using AppointmentService.API.Entities;

namespace AppointmentService.API.Interfaces.Mappers;
public interface IAppointmentTimeMapper
{
    AppointmentTime SaveToDomain(AppointmentTimeSave appointmentTimeSave);
    AppointmentTimeCreatedEvent DomainToTimeCreatedEvent(AppointmentTime appointmentTime);
}
