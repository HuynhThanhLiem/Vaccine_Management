using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using VaccineManagement.Models;
using VaccineManagement.Settings;

namespace VaccineManagement.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailForForgotPasswordAsync(ResponeMailForgotPassword res, string passwordResetLink)
        {

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"﻿<!DOCTYPE html>\n"
                            + "<html>\n"
                            + "<head>\n"
                            + "<meta charset = \"utf-8\" />\n"
                            + "<title></title>\n"
                            + "</head>"
                            + "<body>"
                            + "<p>"
                            + "Hello " + res.ToEmail + ", <br />"
                            + "<br />"
                            + "Click on the following link to reset your password: "
                            + "<a href = \"" + passwordResetLink + "\"> Reset password </a>"
                            + "</body>"
                            + "</html>",
                TextBody = passwordResetLink,
            };

            var message = new MimeMessage
            {
                Body = bodyBuilder.ToMessageBody()
            };

            message.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            message.To.Add(MailboxAddress.Parse(res.ToEmail));
            message.Subject = "Reset your password";

            using var smtp = new SmtpClient();

            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);

            await smtp.SendAsync(message);
            smtp.Disconnect(true);
        }
    }
}
