using DoctorService.API.Contracts;
using DoctorService.API.Interfaces.Mappers;
using DoctorService.API.Interfaces.Repositories;
using DoctorService.API.Interfaces.Services;

namespace DoctorService.API.Services;
public sealed class ScheduleService(IScheduleRepository scheduleRepository, IScheduleMapper scheduleMapper) : IScheduleService
{
    public async Task AddAsync(AppointmentTimeCreatedEvent appointmentTimeCreatedEvent)
    {
        var schedule = scheduleMapper.AppointmentTimeCreatedEventToDomain(appointmentTimeCreatedEvent);

        await scheduleRepository.AddAsync(schedule);
    }
}
