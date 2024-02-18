using DoctorService.API.Contracts;
using DoctorService.API.DataTransferObjects.Schedule;
using DoctorService.API.Entities;

namespace DoctorService.API.Interfaces.Mappers;
public interface IScheduleMapper
{
    List<ScheduleResponse> DomainListToResponseList(List<Schedule> scheduleList);
    Schedule AppointmentTimeCreatedEventToDomain(AppointmentTimeCreatedEvent appointmentTimeCreatedEvent);
}
