using DoctorService.API.Settings.PaginationSettings;

namespace DoctorService.API.Arguments;
public sealed class DoctorGetAllFilterArgument : PageParameters
{
    public required List<int> SpecialityIds { get; set; }
    public DateTime? InitialTime { get; set; }
    public DateTime? FinalTime { get; set; }
}
