﻿namespace DoctorService.API.DataTransferObjects.Schedule;
public sealed class ScheduleResponse
{
    public required int Id { get; set; }
    public required DateTime Time { get; set; }
}
