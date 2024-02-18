using DoctorService.API.DataTransferObjects.Certification;

namespace DoctorService.API.DataTransferObjects.DoctorAttendant;
public sealed record DoctorAttendantSave(string Name,
                                         int ExperienceYears,
                                         DateTime BirthDate,
                                         CertificationRequest Certification,
                                         List<int> SpecialityIds);
