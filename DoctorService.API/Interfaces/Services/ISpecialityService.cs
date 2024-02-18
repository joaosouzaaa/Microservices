using DoctorService.API.DataTransferObjects.Speciality;

namespace DoctorService.API.Interfaces.Services;
public interface ISpecialityService
{
    Task<bool> AddAsync(SpecialitySave specialitySave);
    Task<bool> DeleteAsync(int id);
    Task<List<SpecialityResponse>> GetAllAsync();
}
