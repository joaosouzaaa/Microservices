using PatientService.API.DataTransferObjects.PatientClient;
using PatientService.API.Entities;

namespace PatientService.API.Interfaces.Mappers;
public interface IPatientClientMapper
{
    PatientClient SaveToDomain(PatientClientSave patientClientSave);
    void UpdateToDomain(PatientClientUpdate patientClientUpdate, PatientClient patientClient);
    PatientClientResponse DomainToResponse(PatientClient patientClient);
}
