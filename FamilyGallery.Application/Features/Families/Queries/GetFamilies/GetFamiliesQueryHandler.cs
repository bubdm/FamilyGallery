using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FamilyGallery.Application.Features.Families;

namespace FamilyGallery.Application.Features.Families.GetFamilies
{
    public class GetFamiliesQueryHandler : IRequestHandler<GetFamiliesQuery, List<FamilyVm>>
    {
        private readonly IMapper mapper;
        private readonly IFamilyRepository familyRepository;

        public GetFamiliesQueryHandler(IMapper mapper, IFamilyRepository familyRepository)
        {
            this.mapper = mapper;
            this.familyRepository = familyRepository;
        }
        public async Task<List<FamilyVm>> Handle(GetFamiliesQuery request, CancellationToken cancellationToken)
        {
            var families = await familyRepository.ListAllAsync();
            return mapper.Map<List<FamilyVm>>(families);
        }
    }
}
