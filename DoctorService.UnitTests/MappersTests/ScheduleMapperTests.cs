using DoctorService.API.Entities;
using DoctorService.API.Mappers;
using DoctorService.UnitTests.TestBuilders;

namespace DoctorService.UnitTests.MappersTests;
public sealed class ScheduleMapperTests
{
    private readonly ScheduleMapper _scheduleMapper;

    public ScheduleMapperTests()
    {
        _scheduleMapper = new ScheduleMapper();
    }

    [Fact]
    public void DomainListToResponseList_SuccessfulScenario()
    {
        // A
        var scheduleList = new List<Schedule>()
        {
            ScheduleBuilder.NewObject().DomainBuild()
        };

        // A
        var scheduleResponseListResult = _scheduleMapper.DomainListToResponseList(scheduleList);

        // A
        Assert.Equal(scheduleResponseListResult.Count, scheduleList.Count);
    }

    [Fact]
    public void AppointmentTimeCreatedEventToDomain_SuccessfulScenario()
    {
        // A
        var appointmentTimeCreatedEvent = ContractsBuilder.NewObject().AppointmentTimeCreatedEventBuild();

        // A
        var scheduleResult = _scheduleMapper.AppointmentTimeCreatedEventToDomain(appointmentTimeCreatedEvent);

        // A
        Assert.Equal(scheduleResult.DoctorAttendantId, appointmentTimeCreatedEvent.DoctorAttendantId);
        Assert.Equal(scheduleResult.Time, appointmentTimeCreatedEvent.Time);
    }
}
