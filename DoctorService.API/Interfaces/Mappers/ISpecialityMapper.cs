using DoctorService.API.DataTransferObjects.Speciality;
using DoctorService.API.Entities;

namespace DoctorService.API.Interfaces.Mappers;
public interface ISpecialityMapper
{
    Speciality SaveToDomain(SpecialitySave specialitySave);
    List<SpecialityResponse> DomainLisToResponseList(List<Speciality> specialityList);
}
