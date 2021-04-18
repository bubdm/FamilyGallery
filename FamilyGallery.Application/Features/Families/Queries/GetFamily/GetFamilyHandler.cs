using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.GetFamily
{
    public class GetFamilyHandler : IRequestHandler<GetFamilyQuery, FamilyVm>
    {
        private readonly IMapper mapper;
        private readonly IFamilyRepository familyRepository;
        private readonly IFamilyMemberRepository familyMemberRepository;

        public GetFamilyHandler(IMapper mapper, IFamilyRepository familyRepository, IFamilyMemberRepository familyMemberRepository)
        {
            this.mapper = mapper;
            this.familyRepository = familyRepository;
            this.familyMemberRepository = familyMemberRepository;
        }
        public async Task<FamilyVm> Handle(GetFamilyQuery request, CancellationToken cancellationToken)
        {
            var family = await familyRepository.GetByIdAsync(request.Id);
            var familyVm = mapper.Map<FamilyVm>(family);
            var members = familyMemberRepository.GetByFamily(request.Id);
            familyVm.Members = mapper.Map<List<UserVm>>(members);
            return familyVm;
        }
    }
}
