using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Files.Commands.DeleteFile
{
    public class DeleteFileCommandValidator : AbstractValidator<DeleteFileCommand>
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IFileRepository fileRepository;

        public DeleteFileCommandValidator(IAlbumRepository albumRepository, IFileRepository fileRepository)
        {
            this.albumRepository = albumRepository;
            this.fileRepository = fileRepository;
            RuleFor(f => f).MustAsync(UploaderOwnsAlbum).WithMessage("You cannot upload to another's album");
            RuleFor(f => f).MustAsync(UploaderOwnsFile).WithMessage("You cannot delete another's file");
        }

        private async Task<bool> UploaderOwnsAlbum(DeleteFileCommand deleteFileCommand, CancellationToken arg2)
        {
            return await albumRepository.IsAlbumOwnerAsync(deleteFileCommand.AlbumId, deleteFileCommand.CreatorId);
        }

        private async Task<bool> UploaderOwnsFile(DeleteFileCommand deleteFileCommand, CancellationToken arg2)
        {
            return await fileRepository.IsOwner(deleteFileCommand.FileId, deleteFileCommand.CreatorId);
        }
    }
}
