﻿using PatientService.API.Mappers;
using PatientService.UnitTests.TestBuilders;

namespace PatientService.UnitTests.MappersTests;
public sealed class ContactInfoMapperTests
{
    private readonly ContactInfoMapper _contactInfoMapper;

    public ContactInfoMapperTests()
    {
        _contactInfoMapper = new ContactInfoMapper();
    }

    [Fact]
    public void RequestToDomainCreate_SuccessfulScenario()
    {
        // A
        var contactInfoRequest = ContactInfoBuilder.NewObject().RequestBuild();

        // A
        var contactInfoResult = _contactInfoMapper.RequestToDomainCreate(contactInfoRequest);

        // A
        Assert.Equal(contactInfoResult.Email, contactInfoRequest.Email);
        Assert.Equal(contactInfoResult.PhoneNumber, contactInfoRequest.PhoneNumber);
    }

    [Fact]
    public void RequestToDomainUpdate_SuccessfulScenario()
    {
        // A
        var contactInfoRequest = ContactInfoBuilder.NewObject().RequestBuild();
        var contactInfoResult = ContactInfoBuilder.NewObject().DomainBuild();

        // A
        _contactInfoMapper.RequestToDomainUpdate(contactInfoRequest, contactInfoResult);

        // A
        Assert.Equal(contactInfoResult.Email, contactInfoRequest.Email);
        Assert.Equal(contactInfoResult.PhoneNumber, contactInfoRequest.PhoneNumber);
    }

    [Fact]
    public void DomainToResponse_SuccessfulScenario()
    {
        // A
        var contactInfo = ContactInfoBuilder.NewObject().DomainBuild();

        // A
        var contactInfoResponseResult = _contactInfoMapper.DomainToResponse(contactInfo);

        // A
        Assert.Equal(contactInfoResponseResult.Email, contactInfo.Email);
        Assert.Equal(contactInfoResponseResult.Id, contactInfo.Id);
        Assert.Equal(contactInfoResponseResult.PhoneNumber, contactInfo.PhoneNumber);
    }
}
