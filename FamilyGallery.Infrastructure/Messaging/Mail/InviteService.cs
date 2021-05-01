using FamilyGallery.Application.Contracts.Infrastructure;
using FamilyGallery.Application.Features.FamilyMembers.Commands.CreateFamilyMember;
using FamilyGallery.Application.Models.Mail;
using FamilyGallery.Domain.Entities;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FamilyGallery.Infrastructure.Messaging.Mail
{
    public class InviteService : IInviteService
    {
        private readonly EmailTemplates emailTemplates;
        private readonly IEmailService emailService;

        public InviteService(IOptions<EmailTemplates> emailTemplates, IEmailService emailService)
        {
            this.emailTemplates = emailTemplates.Value;
            this.emailService = emailService;
        }

        public Task<bool> InviteFamilyMember(CreateFamilyMemberCommand createFamilyMember)
        {
            var email = new Email()
            {
                Name = createFamilyMember.Email,
                EmailAddress = createFamilyMember.FirstName,
                Body = emailTemplates.FamilyMemberInvite.Body,
                Subject = emailTemplates.FamilyMemberInvite.Subject
            };
            return emailService.Send(email);
        }
    }
}
