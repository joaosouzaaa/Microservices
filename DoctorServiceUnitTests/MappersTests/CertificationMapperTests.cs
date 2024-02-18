using DoctorService.API.Mappers;
using DoctorServiceUnitTests.TestBuilders;

namespace DoctorServiceUnitTests.MappersTests;
public sealed class CertificationMapperTests
{
    private readonly CertificationMapper _certificationMapper;

    public CertificationMapperTests()
    {
        _certificationMapper = new CertificationMapper();
    }

    [Fact]
    public void RequestToDomainCreate_SuccessfulScenario()
    {
        // A
        var certificationRequest = CertificationBuilder.NewObject().RequestBuild();

        // A
        var certificationResult = _certificationMapper.RequestToDomainCreate(certificationRequest);

        // A
        Assert.Equal(certificationResult.LicenseNumber, certificationRequest.LicenseNumber);
    }

    [Fact]
    public void RequestToDomainUpdate_SuccessfulScenario()
    {
        // A
        var certificationRequest = CertificationBuilder.NewObject().RequestBuild();
        var certificationResult = CertificationBuilder.NewObject().DomainBuild();

        // A
        _certificationMapper.RequestToDomainUpdate(certificationRequest, certificationResult);

        // A
        Assert.Equal(certificationResult.LicenseNumber, certificationRequest.LicenseNumber);
    }

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var certification = CertificationBuilder.NewObject().DomainBuild();

        // A
        var certificationResponseResult = _certificationMapper.DomainToResponse(certification);

        // A
        Assert.Equal(certificationResponseResult.Id, certification.Id);
        Assert.Equal(certificationResponseResult.LicenseNumber, certification.LicenseNumber);
    }
}
