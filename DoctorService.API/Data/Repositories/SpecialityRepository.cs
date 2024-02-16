using DoctorService.API.Data.DatabaseContexts;
using DoctorService.API.Data.Repositories.BaseRepositories;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.API.Data.Repositories;
public sealed class SpecialityRepository(AppDbContext dbContext) : BaseRepository<Speciality>(dbContext), ISpecialityRepository
{
    public async Task<bool> AddAsync(Speciality speciality)
    {
        await DbContextSet.AddAsync(speciality);

        return await SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(int id) =>
        DbContextSet.AsNoTracking().AnyAsync(s => s.Id == id);

    public async Task<bool> DeleteAsync(int id)
    {
        var speciality = await DbContextSet.FirstOrDefaultAsync(s => s.Id == id);

        DbContextSet.Remove(speciality!);

        return await SaveChangesAsync();
    }

    public Task<List<Speciality>> GetAllAsync() =>
        DbContextSet.AsNoTracking().ToListAsync();

    public Task<Speciality?> GetByIdAsync(int id) =>
        DbContextSet.FirstOrDefaultAsync(s => s.Id == id);
}
