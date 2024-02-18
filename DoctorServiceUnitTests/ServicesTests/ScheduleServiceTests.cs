using DoctorService.API.Contracts;
using DoctorService.API.Entities;
using DoctorService.API.Interfaces.Mappers;
using DoctorService.API.Interfaces.Repositories;
using DoctorService.API.Services;
using DoctorServiceUnitTests.TestBuilders;
using Moq;

namespace DoctorServiceUnitTests.ServicesTests;
public sealed class ScheduleServiceTests
{
    private readonly Mock<IScheduleRepository> _scheduleRepositoryMock;
    private readonly Mock<IScheduleMapper> _scheduleMapperMock;
    private readonly ScheduleService _scheduleService;

    public ScheduleServiceTests()
    {
        _scheduleRepositoryMock = new Mock<IScheduleRepository>();
        _scheduleMapperMock = new Mock<IScheduleMapper>();
        _scheduleService = new ScheduleService(_scheduleRepositoryMock.Object, _scheduleMapperMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario()
    {
        // A
        var appointmentTimeCreatedEvent = ContractsBuilder.NewObject().AppointmentTimeCreatedEventBuild();

        var schedule = ScheduleBuilder.NewObject().DomainBuild();
        _scheduleMapperMock.Setup(s => s.AppointmentTimeCreatedEventToDomain(It.IsAny<AppointmentTimeCreatedEvent>()))
            .Returns(schedule);

        _scheduleRepositoryMock.Setup(s => s.AddAsync(It.IsAny<Schedule>()))
            .ReturnsAsync(true);

        // A
        await _scheduleService.AddAsync(appointmentTimeCreatedEvent);

        // A
        _scheduleMapperMock.Verify(s => s.AppointmentTimeCreatedEventToDomain(It.IsAny<AppointmentTimeCreatedEvent>()), Times.Once());
        _scheduleRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Schedule>()), Times.Once());
    }
}
