using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.DeleteFamily
{
    public class DeleteFamilyCommandValidator : AbstractValidator<DeleteFamilyCommand>
    {
        private readonly IFamilyRepository familyRepository;

        public DeleteFamilyCommandValidator(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;
            RuleFor(f => f).MustAsync(DeleterMustBeFamilyCreator).WithMessage("A family can only be deleted by it's creator");
        }

        private async Task<bool> DeleterMustBeFamilyCreator(DeleteFamilyCommand deleteFamilyCommand, CancellationToken arg2)
        {
            var family = await familyRepository.GetByIdAsync(deleteFamilyCommand.FamilyId);
            return family.CreatorId == deleteFamilyCommand.DeleterId;
        }
    }
}
