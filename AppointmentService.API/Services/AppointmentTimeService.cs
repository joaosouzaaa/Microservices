using AppointmentService.API.DataTransferObjects.Appointment;
using AppointmentService.API.Entities;
using AppointmentService.API.Enums;
using AppointmentService.API.Extensions;
using AppointmentService.API.Interfaces.Mappers;
using AppointmentService.API.Interfaces.Publishers;
using AppointmentService.API.Interfaces.Repositories;
using AppointmentService.API.Interfaces.Services;
using AppointmentService.API.Interfaces.Settings;
using FluentValidation;

namespace AppointmentService.API.Services;
public sealed class AppointmentTimeService(IAppointmentTimeRepository appointmentTimeRepository, IAppointmentPublisher appointmentPublisher,
                                           IAppointmentTimeMapper appointmentTimeMapper, INotificationHandler notificationHandler,
                                           IValidator<AppointmentTime> validator) : IAppointmentTimeService
{

    public async Task<bool> AddAsync(AppointmentTimeSave appointmentTimeSave)
    {
        if (await appointmentTimeRepository.ExistsByTimeAndDoctorAsync(appointmentTimeSave.DoctorAttendantId, appointmentTimeSave.Time))
        {
            notificationHandler.AddNotification(nameof(EMessage.Exists), EMessage.Exists.Description().FormatTo("Time"));

            return false;
        }

        var appointmentTime = appointmentTimeMapper.SaveToDomain(appointmentTimeSave);

        if (!await ValidateAsync(appointmentTime))
            return false;

        var addResult = await appointmentTimeRepository.AddAsync(appointmentTime);

        var appointmentTimeCreatedEvent = appointmentTimeMapper.DomainToTimeCreatedEvent(appointmentTime);
        appointmentPublisher.PublishAppointmentTimeCreatedMessage(appointmentTimeCreatedEvent);

        return addResult;
    }

    private async Task<bool> ValidateAsync(AppointmentTime appointmentTime)
    {
        var validationResult = await validator.ValidateAsync(appointmentTime);

        if (validationResult.IsValid)
            return true;

        foreach (var error in validationResult.Errors)
        {
            notificationHandler.AddNotification(error.PropertyName, error.ErrorMessage);
        }

        return false;
    }
}
