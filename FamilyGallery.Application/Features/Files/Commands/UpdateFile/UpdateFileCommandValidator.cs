using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Files.Commands.UpdateFile
{
    public class UpdateFileCommandValidator : AbstractValidator<UpdateFileCommand>
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IFileRepository fileRepository;

        public UpdateFileCommandValidator(IAlbumRepository albumRepository, IFileRepository fileRepository)
        {
            this.albumRepository = albumRepository;
            this.fileRepository = fileRepository;
            RuleFor(f => f.Path).NotEmpty().NotNull().WithMessage("{PropertyName} required");
            RuleFor(f => f.ContentType).NotEmpty().NotNull().WithMessage("{PropertyName} required");
            RuleFor(f => f.Extension).NotEmpty().NotNull().WithMessage("{PropertyName} required");
            RuleFor(f => f.FileSize).GreaterThan(0).WithMessage("{PropertyName} required");
            RuleFor(f => f).MustAsync(UploaderOwnsAlbum).WithMessage("You cannot upload to another's album");
            RuleFor(f => f).MustAsync(UploaderOwnsFile).WithMessage("You cannot update another's file");
        }

        private async Task<bool> UploaderOwnsAlbum(UpdateFileCommand updateFileCommand, CancellationToken arg2)
        {
            return await albumRepository.IsAlbumOwnerAsync(updateFileCommand.AlbumId, updateFileCommand.CreatorId);
        }

        private async Task<bool> UploaderOwnsFile(UpdateFileCommand updateFileCommand, CancellationToken arg2)
        {
            return await fileRepository.IsOwner(updateFileCommand.FileId, updateFileCommand.CreatorId);
        }
    }
}
