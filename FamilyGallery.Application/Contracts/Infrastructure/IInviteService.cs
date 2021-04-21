using FamilyGallery.Application.Features.FamilyMembers.Commands.CreateFamilyMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Infrastructure
{
    public interface IInviteService
    {
        Task<bool> InviteFamilyMember(CreateFamilyMemberCommand createFamilyMember);
    }
}
