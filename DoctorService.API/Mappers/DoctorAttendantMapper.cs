using DoctorService.API.Arguments;
using DoctorService.API.DataTransferObjects.DoctorAttendant;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Mappers;
using DoctorService.API.Settings.PaginationSettings;

namespace DoctorService.API.Mappers;
public sealed class DoctorAttendantMapper(ICertificationMapper certificationMapper, IScheduleMapper scheduleMapper,
                                          ISpecialityMapper specialityMapper) : IDoctorAttendantMapper
{
    public DoctorAttendant SaveToDomain(DoctorAttendantSave doctorAttendantSave) =>
        new()
        {
            BirthDate = DateOnly.FromDateTime(doctorAttendantSave.BirthDate),
            Certification = certificationMapper.RequestToDomainCreate(doctorAttendantSave.Certification),
            ExperienceYears = doctorAttendantSave.ExperienceYears,
            Name = doctorAttendantSave.Name,
            Schedules = [],
            Specialities = []
        };

    public void UpdateToDomain(DoctorAttendantUpdate doctorAttendantUpdate, DoctorAttendant doctorAttendant)
    {
        doctorAttendant.BirthDate = DateOnly.FromDateTime(doctorAttendantUpdate.BirthDate);
        doctorAttendant.ExperienceYears = doctorAttendantUpdate.ExperienceYears;
        doctorAttendant.Name = doctorAttendantUpdate.Name;

        certificationMapper.RequestToDomainUpdate(doctorAttendantUpdate.Certification, doctorAttendant.Certification);
    }

    public DoctorAttendantResponse DomainToResponse(DoctorAttendant doctorAttendant) =>
        new()
        {
            BirthDate = doctorAttendant.BirthDate,
            Certification = certificationMapper.DomainToResponse(doctorAttendant.Certification),
            ExperienceYears = doctorAttendant.ExperienceYears,
            Id = doctorAttendant.Id,
            Name = doctorAttendant.Name,
            Schedules = scheduleMapper.DomainListToResponseList(doctorAttendant.Schedules),
            Specialities = specialityMapper.DomainLisToResponseList(doctorAttendant.Specialities)
        };

    public DoctorGetAllFilterArgument FilterRequestToArgumentDomain(DoctorGetAllFilterRequest doctorGetAllFilterRequest) =>
        new()
        {
            FinalTime = doctorGetAllFilterRequest.FinalTime,
            InitialTime = doctorGetAllFilterRequest.InitialTime,
            PageNumber = doctorGetAllFilterRequest.PageNumber,
            PageSize = doctorGetAllFilterRequest.PageSize,
            SpecialityIds = doctorGetAllFilterRequest.SpecialityIds
        };

    public PageList<DoctorAttendantResponse> DomainPageListToResponsePageList(PageList<DoctorAttendant> doctorAttendantPageList) =>
        new()
        {
            CurrentPage = doctorAttendantPageList.CurrentPage,
            PageSize = doctorAttendantPageList.PageSize,
            Result = doctorAttendantPageList.Result.Select(DomainToResponse).ToList(),
            TotalCount = doctorAttendantPageList.TotalCount,
            TotalPages = doctorAttendantPageList.TotalPages
        };
}
