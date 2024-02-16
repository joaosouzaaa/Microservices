using DoctorService.API.Arguments;
using DoctorService.API.Entities;
using DoctorService.API.Settings.PaginationSettings;

namespace DoctorService.API.Interfaces.Repositories;
public interface IDoctorAttendantRepository
{
    Task<bool> AddAsync(DoctorAttendant doctorAttendant);
    Task<bool> UpdateAsync(DoctorAttendant doctorAttendant);
    Task<PageList<DoctorAttendant>> GetAllFilteredAndPaginatedAsync(DoctorGetAllFilterArgument filter);
    Task<DoctorAttendant?> GetByIdAsync(int id, bool asNoTracking);
}
