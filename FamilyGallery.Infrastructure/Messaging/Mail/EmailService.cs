using FamilyGallery.Application.Contracts.Infrastructure;
using FamilyGallery.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace FamilyGallery.Infrastructure.Messaging.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        public async Task<bool> Send(Email email)
        {
            var client = new SendGridClient(emailSettings.ApiKey);
            var from = new EmailAddress { Email = emailSettings.FromAddress, Name = emailSettings.FromName };
            var to = new EmailAddress { Email = email.EmailAddress, Name = email.Name };
            var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, "");
            var response = await client.SendEmailAsync(msg);
            return response.StatusCode is System.Net.HttpStatusCode.Accepted or System.Net.HttpStatusCode.OK;
        }
    }
}
