using PatientService.API.DataTransferObjects.PatientClient;

namespace PatientService.API.Interfaces.Services;
public interface IPatientClientService
{
    Task<bool> AddAsync(PatientClientSave patientClientSave);
    Task<bool> UpdateAsync(PatientClientUpdate patientClientUpdate);
    Task<PatientClientResponse?> GetByIdAsync(int id);
}
