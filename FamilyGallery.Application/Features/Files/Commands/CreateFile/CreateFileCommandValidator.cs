using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Files.Commands.CreateFile
{
    public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
    {
        private readonly IAlbumRepository albumRepository;

        public CreateFileCommandValidator(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
            RuleFor(f => f.Path).NotEmpty().NotNull().WithMessage("{PropertyName} required");
            RuleFor(f => f.ContentType).NotEmpty().NotNull().WithMessage("{PropertyName} required");
            RuleFor(f => f.Extension).NotEmpty().NotNull().WithMessage("{PropertyName} required");
            RuleFor(f => f.FileSize).GreaterThan(0).WithMessage("{PropertyName} required");
            RuleFor(f => f).MustAsync(UploaderOwnsAlbum).WithMessage("You cannot upload to another's album");
        }

        private async Task<bool> UploaderOwnsAlbum(CreateFileCommand createFileCommand, CancellationToken arg2)
        {
            return await albumRepository.IsAlbumOwnerAsync(createFileCommand.AlbumId, createFileCommand.CreatorId);
        }
    }
}
