using DoctorService.API.DataTransferObjects.Certification;
using DoctorService.API.DataTransferObjects.Schedule;
using DoctorService.API.DataTransferObjects.Speciality;

namespace DoctorService.API.DataTransferObjects.DoctorAttendant;
public sealed class DoctorAttendantResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int ExperienceYears { get; set; }
    public required DateOnly BirthDate { get; set; }

    public required CertificationResponse Certification { get; set; }
    public required List<ScheduleResponse> Schedules { get; set; }
    public required List<SpecialityResponse> Specialities { get; set; }
}
