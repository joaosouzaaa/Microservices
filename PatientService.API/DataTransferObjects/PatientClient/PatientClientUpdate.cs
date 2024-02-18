using PatientService.API.DataTransferObjects.ContactInfo;

namespace PatientService.API.DataTransferObjects.PatientClient;
public sealed record PatientClientUpdate(int Id,
                                         string Name,
                                         string Address,
                                         ContactInfoRequest ContactInfo);
