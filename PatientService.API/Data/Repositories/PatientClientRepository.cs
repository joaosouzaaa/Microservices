using Microsoft.EntityFrameworkCore;
using Patient.Infrastructure.Interfaces.Repositories;
using PatientService.API.Data.DatabaseContexts;
using PatientService.API.Data.Interfaces.Repositories;
using PatientService.API.Entities;

namespace PatientService.API.Data.Repositories;
public sealed class PatientClientRepository(AppDbContext dbContext) : IPatientClientRepository, IPatientClientRepositoryFacade, IDisposable
{
    private DbSet<PatientClient> DbContextSet => dbContext.Set<PatientClient>();

    public async Task<bool> AddAsync(PatientClient patientClient)
    {
        await DbContextSet.AddAsync(patientClient);

        return await SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(PatientClient patientClient)
    {
        dbContext.Entry(patientClient.ContactInfo).State = EntityState.Modified;
        dbContext.Entry(patientClient).State = EntityState.Modified;

        return await SaveChangesAsync();
    }

    public Task<PatientClient?> GetByIdAsync(int id, bool asNoTracking)
    {
        var query = (IQueryable<PatientClient>)DbContextSet;

        if (asNoTracking)
            query = DbContextSet.AsNoTracking();

        return query.Include(p => p.ContactInfo).FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<string?> GetEmailByIdAsync(int id) =>
        DbContextSet.Where(p => p.Id == id).Select(p => p.ContactInfo.Email).FirstOrDefaultAsync();

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    private async Task<bool> SaveChangesAsync() =>
        await dbContext.SaveChangesAsync() > 0;
}
