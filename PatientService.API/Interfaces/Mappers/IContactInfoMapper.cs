using PatientService.API.DataTransferObjects.ContactInfo;
using PatientService.API.Entities;

namespace PatientService.API.Interfaces.Mappers;
public interface IContactInfoMapper
{
    ContactInfo RequestToDomainCreate(ContactInfoRequest contactInfoRequest);
    void RequestToDomainUpdate(ContactInfoRequest contactInfoRequest, ContactInfo contactInfo);
    ContactInfoResponse DomainToResponse(ContactInfo contactInfo);
}
