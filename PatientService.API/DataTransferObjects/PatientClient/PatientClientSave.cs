using PatientService.API.DataTransferObjects.ContactInfo;

namespace PatientService.API.DataTransferObjects.PatientClient;
public sealed record PatientClientSave(string Name,
                                       string Address,
                                       ContactInfoRequest ContactInfo);
