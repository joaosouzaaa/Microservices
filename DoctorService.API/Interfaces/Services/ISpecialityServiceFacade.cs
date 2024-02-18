using DoctorService.API.Entities;

namespace DoctorService.API.Interfaces.Services;
public interface ISpecialityServiceFacade
{
    Task<Speciality?> GetByIdReturnsDomainObjectAsync(int id);
}
