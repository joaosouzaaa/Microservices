using DoctorService.API.Data.DatabaseContexts;
using DoctorService.API.Data.Repositories.BaseRepositories;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Repositories;

namespace DoctorService.API.Data.Repositories;
public sealed class ScheduleRepository(AppDbContext dbContext) : BaseRepository<Schedule>(dbContext), IScheduleRepository
{
    public async Task<bool> AddAsync(Schedule schedule)
    {
        await DbContextSet.AddAsync(schedule);

        return await SaveChangesAsync();
    }
}
