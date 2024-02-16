using DoctorService.API.Entities;

namespace DoctorService.API.Interfaces.Repositories;
public interface IScheduleRepository
{
    Task<bool> AddAsync(Schedule schedule);
}
