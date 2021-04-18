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
        private readonly IFamilyMemberRepository familyMemberRepository;

        public UpdateFamilyCommandValidator(IFamilyMemberRepository repository)
        {
            this.familyMemberRepository = repository;

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(f => f).MustAsync(EditedByFamilyMember).WithMessage("Only family members can edit a family");
        }

        private async Task<bool> EditedByFamilyMember(UpdateFamilyCommand command, CancellationToken token)
        {
            return ! await familyMemberRepository.IsFamilyMember(command.Id, command.UpdaterId);
        }
    }
}
