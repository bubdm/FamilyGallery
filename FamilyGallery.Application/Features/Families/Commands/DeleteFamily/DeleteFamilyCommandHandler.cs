using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.DeleteFamily
{
    public class DeleteFamilyCommandHandler : IRequestHandler<DeleteFamilyCommand>
    {
        private readonly IFamilyRepository familyRepository;

        public DeleteFamilyCommandHandler(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;
        }
        public async Task<Unit> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
        {
            var family = await familyRepository.GetByIdAsync(request.Id);
            await familyRepository.DeleteAsync(family);
            return Unit.Value;
        }
    }
}
