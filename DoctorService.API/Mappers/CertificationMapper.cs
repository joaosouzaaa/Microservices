using DoctorService.API.DataTransferObjects.Certification;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Mappers;

namespace DoctorService.API.Mappers;
public sealed class CertificationMapper : ICertificationMapper
{
    public Certification RequestToDomainCreate(CertificationRequest certificationRequest) =>
        new()
        {
            LicenseNumber = certificationRequest.LicenseNumber
        };

    public void RequestToDomainUpdate(CertificationRequest certificationRequest, Certification certification) =>
        certification.LicenseNumber = certificationRequest.LicenseNumber;

    public CertificationResponse DomainToResponse(Certification certification) =>
        new()
        {
            Id = certification.Id,
            LicenseNumber = certification.LicenseNumber
        };
}
