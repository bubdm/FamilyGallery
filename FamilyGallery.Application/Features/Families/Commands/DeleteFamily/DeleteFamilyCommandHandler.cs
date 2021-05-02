using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.DeleteFamily
{
    public class DeleteFamilyCommandHandler : IRequestHandler<DeleteFamilyCommand, DeleteFamilyCommandResponse>
    {
        private readonly IFamilyRepository familyRepository;

        public DeleteFamilyCommandHandler(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;
        }
        public async Task<DeleteFamilyCommandResponse> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteFamilyCommandValidator(familyRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new DeleteFamilyCommandResponse { IsSuccessful = true, Message = validationResult.ToString() };
            }
            var family = await familyRepository.GetByIdAsync(request.FamilyId);
            await familyRepository.DeleteAsync(family);
            return new DeleteFamilyCommandResponse { IsSuccessful = true };
        }
    }
}
