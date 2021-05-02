using FluentValidation;

namespace FamilyGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
    {
        public CreateAlbumCommandValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(f => f.Description)                
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 500 characters");
        }
    }
}
