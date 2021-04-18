using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.FamilyMembers.Queries.GetFamilyMember
{
    public class GetFamilyMemberQueryHandler : IRequestHandler<GetFamilyMemberQuery, FamilyMemberVm>
    {
        private readonly IFamilyMemberRepository familyMemberRepository;
        private readonly GetFamilyMemberQuery getFamilyMemberQuery;
        private readonly IMapper mapper;

        public GetFamilyMemberQueryHandler(IFamilyMemberRepository familyMemberRepository, GetFamilyMemberQuery getFamilyMemberQuery, IMapper mapper)
        {
            this.familyMemberRepository = familyMemberRepository;
            this.getFamilyMemberQuery = getFamilyMemberQuery;
            this.mapper = mapper;
        }
        public async Task<FamilyMemberVm> Handle(GetFamilyMemberQuery request, CancellationToken cancellationToken)
        {
            var familyMember = await familyMemberRepository.GetByIdAsync(request.Id);
            return mapper.Map<FamilyMemberVm>(familyMember);
        }
    }
}
