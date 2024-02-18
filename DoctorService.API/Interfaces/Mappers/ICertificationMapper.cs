using DoctorService.API.DataTransferObjects.Certification;
using DoctorService.API.Entities;

namespace DoctorService.API.Interfaces.Mappers;
public interface ICertificationMapper
{
    Certification RequestToDomainCreate(CertificationRequest certificationRequest);
    void RequestToDomainUpdate(CertificationRequest certificationRequest, Certification certification);
    CertificationResponse DomainToResponse(Certification certification);
}
