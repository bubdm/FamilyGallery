using MediatR;
using System;

namespace FamilyGallery.Application.Features.FamilyMembers.Queries.GetFamilyMember
{
    public class GetFamilyMemberQuery : IRequest<FamilyMemberVm>
    {
        public Guid Id { get; internal set; }
    }
}
