using DoctorService.API.Settings.PaginationSettings;

namespace DoctorService.API.DataTransferObjects.DoctorAttendant;
public sealed class DoctorGetAllFilterRequest : PageParameters
{
    public List<int> SpecialityIds { get; set; }
    public DateTime? InitialTime { get; set; }
    public DateTime? FinalTime { get; set; }
}
