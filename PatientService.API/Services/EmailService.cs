using MimeKit;
using MimeKit.Text;
using PatientService.API.Contracts;
using PatientService.API.Interfaces.Repositories;
using PatientService.API.Interfaces.Services;
using PatientService.API.Interfaces.Settings;

namespace PatientService.API.Services;
public sealed class EmailService(IPatientClientRepositoryFacade patientClientRepository, IEmailSender emailSender,
                                 IConfiguration configuration) : IEmailService
{
    public async Task SendAppointmentEmailAsync(AppointmentTimeCreatedEvent appointmentTimeCreatedEvent)
    {
        var to = await patientClientRepository.GetEmailByIdAsync(appointmentTimeCreatedEvent.PatientClientId);

        var mailMessage = new MimeMessage()
        {
            Subject = "Your appointment is booked!",
            To = { MailboxAddress.Parse(to) },
            Body = new TextPart(TextFormat.Text)
            {
                Text = $"Your appointment is booked to {appointmentTimeCreatedEvent.Time.ToString("dd/MM/yyyy HH:mm")}"
            },
            From = { MailboxAddress.Parse(configuration["EmailCredentials:From"]) }
        };

        await emailSender.SendEmailAsync(mailMessage);
    }
}
