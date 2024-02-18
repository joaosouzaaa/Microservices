using PatientService.API.DataTransferObjects.ContactInfo;
using PatientService.API.Entities;
using PatientService.API.Interfaces.Mappers;

namespace PatientService.API.Mappers;
public sealed class ContactInfoMapper : IContactInfoMapper
{
    public ContactInfo RequestToDomainCreate(ContactInfoRequest contactInfoRequest) =>
        new()
        {
            Email = contactInfoRequest.Email,
            PhoneNumber = contactInfoRequest.PhoneNumber
        };

    public void RequestToDomainUpdate(ContactInfoRequest contactInfoRequest, ContactInfo contactInfo)
    {
        contactInfo.Email = contactInfoRequest.Email;
        contactInfo.PhoneNumber = contactInfoRequest.PhoneNumber;
    }

    public ContactInfoResponse DomainToResponse(ContactInfo contactInfo) =>
        new()
        {
            Email = contactInfo.Email,
            Id = contactInfo.Id,
            PhoneNumber = contactInfo.PhoneNumber
        };
}
