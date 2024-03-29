﻿using DoctorService.API.DataTransferObjects.Certification;
using DoctorService.API.Entities;

namespace DoctorService.UnitTests.TestBuilders;
public sealed class CertificationBuilder
{
    private readonly int _id = 123;
    private string _licenseNumber = new string('a', count: 20);

    public static CertificationBuilder NewObject() =>
        new();

    public Certification DomainBuild() =>
        new()
        {
            Id = _id,
            LicenseNumber = _licenseNumber
        };

    public CertificationRequest RequestBuild() =>
        new(_licenseNumber);

    public CertificationResponse ResponseBuild() =>
        new()
        {
            Id = _id,
            LicenseNumber = _licenseNumber
        };

    public CertificationBuilder WithLicenseNumber(string licenseNumber)
    {
        _licenseNumber = licenseNumber;

        return this;
    }
}
