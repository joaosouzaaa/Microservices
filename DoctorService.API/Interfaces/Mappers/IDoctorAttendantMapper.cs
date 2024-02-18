using DoctorService.API.Arguments;
using DoctorService.API.DataTransferObjects.DoctorAttendant;
using DoctorService.API.Entities;
using DoctorService.API.Settings.PaginationSettings;

namespace DoctorService.API.Interfaces.Mappers;
public interface IDoctorAttendantMapper
{
    DoctorAttendant SaveToDomain(DoctorAttendantSave doctorAttendantSave);
    void UpdateToDomain(DoctorAttendantUpdate doctorAttendantUpdate, DoctorAttendant doctorAttendant);
    DoctorAttendantResponse DomainToResponse(DoctorAttendant doctorAttendant);
    DoctorGetAllFilterArgument FilterRequestToArgumentDomain(DoctorGetAllFilterRequest doctorGetAllFilterRequest);
    PageList<DoctorAttendantResponse> DomainPageListToResponsePageList(PageList<DoctorAttendant> doctorAttendantPageList);
}
