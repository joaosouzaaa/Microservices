using PatientService.API.DataTransferObjects.PatientClient;
using PatientService.API.Entities;
using PatientService.API.Interfaces.Mappers;

namespace PatientService.API.Mappers;
public sealed class PatientClientMapper(IContactInfoMapper contactInfoMapper) : IPatientClientMapper
{
    public PatientClient SaveToDomain(PatientClientSave patientClientSave) =>
        new()
        {
            Address = patientClientSave.Address,
            Name = patientClientSave.Name,
            ContactInfo = contactInfoMapper.RequestToDomainCreate(patientClientSave.ContactInfo)
        };

    public void UpdateToDomain(PatientClientUpdate patientClientUpdate, PatientClient patientClient)
    {
        patientClient.Address = patientClientUpdate.Address;
        patientClient.Name = patientClientUpdate.Name;

        contactInfoMapper.RequestToDomainUpdate(patientClientUpdate.ContactInfo, patientClient.ContactInfo);
    }

    public PatientClientResponse DomainToResponse(PatientClient patientClient) =>
        new()
        {
            Address = patientClient.Address,
            Id = patientClient.Id,
            Name = patientClient.Name,
            ContactInfo = contactInfoMapper.DomainToResponse(patientClient.ContactInfo)
        };
}
