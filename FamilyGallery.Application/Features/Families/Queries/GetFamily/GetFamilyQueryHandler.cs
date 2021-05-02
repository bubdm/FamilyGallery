using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Application.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Queries.GetFamily
{
    public class GetFamilyQueryHandler : IRequestHandler<GetFamilyQuery, FamilyVm>
    {
        private readonly IMapper mapper;
        private readonly IFamilyRepository familyRepository;
        private readonly IFamilyMemberRepository familyMemberRepository;

        public GetFamilyQueryHandler(IMapper mapper, IFamilyRepository familyRepository, IFamilyMemberRepository familyMemberRepository)
        {
            this.mapper = mapper;
            this.familyRepository = familyRepository;
            this.familyMemberRepository = familyMemberRepository;
        }
        public async Task<FamilyVm> Handle(GetFamilyQuery request, CancellationToken cancellationToken)
        {
            if(! await familyMemberRepository.IsFamilyMember(request.FamilyId, request.UserId))
            {
                throw new BadRequestException("You are not member of that family" );
            }
            var family = await familyRepository.GetByIdAsync(request.FamilyId);
            var familyVm = mapper.Map<FamilyVm>(family);
            var members = await familyMemberRepository.GetByFamily(request.FamilyId);
            familyVm.Members = mapper.Map<List<UserVm>>(members);
            return familyVm;
        }
    }
}
