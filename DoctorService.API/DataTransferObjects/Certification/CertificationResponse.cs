﻿namespace DoctorService.API.DataTransferObjects.Certification;
public sealed class CertificationResponse
{
    public required int Id { get; set; }
    public required string LicenseNumber { get; set; }
}
