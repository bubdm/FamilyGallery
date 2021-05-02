using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Queries.GetFamiliesWithMembers
{
    public class GetFamiliesWithMembersQueryHandler : IRequestHandler<GetFamiliesWithMembersQuery, List<FamilyVm>>
    {
        private readonly IMapper mapper;
        private readonly IFamilyRepository familyRepository;
        private readonly IFamilyMemberRepository familyMemberRepository;

        public GetFamiliesWithMembersQueryHandler(IMapper mapper, IFamilyRepository familyRepository, IFamilyMemberRepository familyMemberRepository)
        {
            this.mapper = mapper;
            this.familyRepository = familyRepository;
            this.familyMemberRepository = familyMemberRepository;
        }

        public async Task<List<FamilyVm>> Handle(GetFamiliesWithMembersQuery request, CancellationToken cancellationToken)
        {
            var families = await familyRepository.GetWithMembersByUserIdAsync(request.UserId);           
            return mapper.Map<List<FamilyVm>>(families);
        }
    }
}
