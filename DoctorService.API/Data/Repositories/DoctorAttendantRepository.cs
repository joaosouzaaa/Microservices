using DoctorService.API.Arguments;
using DoctorService.API.Data.DatabaseContexts;
using DoctorService.API.Data.Repositories.BaseRepositories;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Repositories;
using DoctorService.API.Settings.PaginationSettings;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.API.Data.Repositories;
public sealed class DoctorAttendantRepository : BaseRepository<DoctorAttendant>, IDoctorAttendantRepository
{
    public DoctorAttendantRepository(AppDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<bool> AddAsync(DoctorAttendant doctorAttendant)
    {
        await DbContextSet.AddAsync(doctorAttendant);

        return await SaveChangesAsync();
    }

    public Task<bool> UpdateAsync(DoctorAttendant doctorAttendant)
    {
        _dbContext.Entry(doctorAttendant.Certification).State = EntityState.Modified;
        _dbContext.Entry(doctorAttendant).State = EntityState.Modified;

        return SaveChangesAsync();
    }

    public Task<PageList<DoctorAttendant>> GetAllFilteredAndPaginatedAsync(DoctorGetAllFilterArgument filter)
    {
        var query = DbContextSet.Include(d => d.Certification)
                                .Include(d => d.Specialities)
                                .Include(d => d.Schedules)
                                .Where(d => d.Specialities.Any(s => filter.SpecialityIds.Contains(s.Id)))
                                .Where(d => filter.InitialTime == null
                                || d.Schedules.Any(s => s.Time >= filter.InitialTime))
                                .Where(d => filter.FinalTime == null
                                || d.Schedules.Any(s => s.Time <= filter.FinalTime));

        return query.PaginateAsync(filter);
    }

    public Task<DoctorAttendant?> GetByIdAsync(int id, bool asNoTracking)
    {
        var query = (IQueryable<DoctorAttendant>)DbContextSet;

        if (asNoTracking)
            query = DbContextSet.AsNoTracking();

        return DbContextSet.Include(d => d.Certification)
                           .Include(d => d.Specialities)
                           .Include(d => d.Schedules)
                           .FirstOrDefaultAsync(d => d.Id == id);
    }
}
