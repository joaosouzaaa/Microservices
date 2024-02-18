using DoctorService.API.Contracts;
using DoctorService.API.DataTransferObjects.Schedule;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Mappers;

namespace DoctorService.API.Mappers;
public sealed class ScheduleMapper : IScheduleMapper
{
    public List<ScheduleResponse> DomainListToResponseList(List<Schedule> scheduleList) =>
        scheduleList.Select(DomainToResponse).ToList();

    public Schedule AppointmentTimeCreatedEventToDomain(AppointmentTimeCreatedEvent appointmentTimeCreatedEvent) =>
        new()
        {
            DoctorAttendantId = appointmentTimeCreatedEvent.DoctorAttendantId,
            Time = appointmentTimeCreatedEvent.Time
        };

    private ScheduleResponse DomainToResponse(Schedule schedule) =>
        new()
        {
            Id = schedule.Id,
            Time = schedule.Time
        };
}
