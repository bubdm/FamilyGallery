using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommandValidator : AbstractValidator<UpdateFamilyCommand>
    {
        private readonly IFamilyRepository familyRepository;

        public UpdateFamilyCommandValidator(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(f => f).MustAsync(EditedByFamilyMember).WithMessage("Only family members can edit a family");
        }

        private async Task<bool> EditedByFamilyMember(UpdateFamilyCommand command, CancellationToken token)
        {
            return ! await familyRepository.IsFamilyMember(command.Id, command.UpdaterId);
        }
    }
}
