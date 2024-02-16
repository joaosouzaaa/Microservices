namespace DoctorService.API.Entities;
public sealed class Certification
{
    public int Id { get; set; }
    public required string LicenseNumber { get; set; }
}
