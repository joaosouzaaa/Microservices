using DoctorService.API.DataTransferObjects.DoctorAttendant;
using DoctorService.API.Settings.PaginationSettings;

namespace DoctorService.API.Interfaces.Services;
public interface IDoctorAttendantService
{
    Task<bool> AddAsync(DoctorAttendantSave doctorAttendantSave);
    Task<bool> UpdateAsync(DoctorAttendantUpdate doctorAttendantUpdate);
    Task<PageList<DoctorAttendantResponse>> GetAllFilteredAndPaginatedAsync(DoctorGetAllFilterRequest filterRequest);
    Task<DoctorAttendantResponse?> GetByIdAsync(int id);
}
