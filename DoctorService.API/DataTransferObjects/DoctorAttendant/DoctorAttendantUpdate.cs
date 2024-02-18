using DoctorService.API.DataTransferObjects.Certification;

namespace DoctorService.API.DataTransferObjects.DoctorAttendant;
public sealed record DoctorAttendantUpdate(int Id,
                                           string Name,
                                           int ExperienceYears,
                                           DateTime BirthDate,
                                           CertificationRequest Certification,
                                           List<int> SpecialityIds);
