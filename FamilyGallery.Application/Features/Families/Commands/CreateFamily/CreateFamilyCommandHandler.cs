using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.CreateFamily
{
    public class CreateFamilyCommandHandler : IRequestHandler<CreateFamilyCommand, Guid>
    {
        private readonly IFamilyRepository familyRepository;
        private readonly IMapper mapper;

        public CreateFamilyCommandHandler(IFamilyRepository familyRepository, IMapper mapper)
        {
            this.familyRepository = familyRepository;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(CreateFamilyCommand request, CancellationToken cancellationToken)
        {
            var family = mapper.Map<Family>(request);
            var result = await familyRepository.AddAsync(family);
            return result.Id;
        }
    }
}
