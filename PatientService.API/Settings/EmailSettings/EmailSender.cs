﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using PatientService.API.Interfaces.Settings;
using PatientService.API.Options;

namespace PatientService.API.Settings.EmailSettings;
public sealed class EmailSender(IOptions<EmailCredentialsOptions> emailOptions) : IEmailSender
{
    private readonly EmailCredentialsOptions _emailCredentialsOptions = emailOptions.Value;

    public async Task SendEmailAsync(MimeMessage mailMessage)
    {
        using var smtpClient = new SmtpClient();

        await smtpClient.ConnectAsync(_emailCredentialsOptions.Host, _emailCredentialsOptions.Port, SecureSocketOptions.StartTls);
        await smtpClient.AuthenticateAsync(_emailCredentialsOptions.From, _emailCredentialsOptions.Password);

        await smtpClient.SendAsync(mailMessage);

        await smtpClient.DisconnectAsync(true);
    }
}
