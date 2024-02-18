using DoctorService.API.DataTransferObjects.Speciality;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Mappers;

namespace DoctorService.API.Mappers;
public sealed class SpecialityMapper : ISpecialityMapper
{
    public Speciality SaveToDomain(SpecialitySave specialitySave) =>
        new()
        {
            Name = specialitySave.Name
        };

    public List<SpecialityResponse> DomainLisToResponseList(List<Speciality> specialityList) =>
        specialityList.Select(DomainToResponse).ToList();

    private SpecialityResponse DomainToResponse(Speciality speciality) =>
        new()
        {
            Id = speciality.Id,
            Name = speciality.Name
        };
}
