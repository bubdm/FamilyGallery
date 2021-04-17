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

namespace FamilyGallery.Application.Features.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommandHandler : IRequestHandler<UpdateFamilyCommand>
    {
        private readonly IMapper mapper;
        private readonly IFamilyRepository familyRepository;

        public UpdateFamilyCommandHandler(IMapper mapper, IFamilyRepository familyRepository)
        {
            this.mapper = mapper;
            this.familyRepository = familyRepository;
        }
        public async Task<Unit> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
        {
            var family = await familyRepository.GetByIdAsync(request.Id);
            mapper.Map(request, family, typeof(UpdateFamilyCommand), typeof(Family));
            await familyRepository.UpdateAsync(family);
            return Unit.Value;
        }
    }
}
