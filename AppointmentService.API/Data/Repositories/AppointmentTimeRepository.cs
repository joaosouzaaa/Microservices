using AppointmentService.API.Data.DatabaseContexts;
using AppointmentService.API.Entities;
using AppointmentService.API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.API.Data.Repositories;
public sealed class AppointmentTimeRepository(AppDbContext dbContext) : IAppointmentTimeRepository
{
    private DbSet<AppointmentTime> DbContextSet => dbContext.Set<AppointmentTime>();

    public async Task<bool> AddAsync(AppointmentTime appointmentTime)
    {
        await DbContextSet.AddAsync(appointmentTime);

        return await dbContext.SaveChangesAsync() > 0;
    }

    public Task<bool> ExistsByTimeAndDoctorAsync(int doctorAttendantId, DateTime time) =>
        DbContextSet.AnyAsync(a => a.DoctorAttendantId == doctorAttendantId && a.Time == time);
}
