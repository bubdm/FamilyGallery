using MediatR;
using System;
using System.Collections.Generic;

namespace FamilyGallery.Application.Features.Families.Queries.GetFamiliesWithMembers
{
    public class GetFamiliesWithMembersQuery : IRequest<List<FamilyVm>>
    {
        public Guid UserId { get; set; }        
    }
}
