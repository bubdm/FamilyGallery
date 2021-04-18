using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.FamilyMembers.Queries.GetFamilyMember
{
    public class GetFamilyMemberQuery : IRequest<FamilyMemberVm>
    {
        public Guid Id { get; internal set; }
    }
}
