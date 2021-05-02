using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.DeleteAlbum
{
    class DeleteAlbumCommandValidator : AbstractValidator<DeleteAlbumCommand>
    {
        private readonly IAlbumRepository albumRepository;

        public DeleteAlbumCommandValidator(IAlbumRepository albumRepository)
        {
            RuleFor(a => a).MustAsync(DeleterIsAlbumOwner).WithMessage("An album can only be deleted by it's owner");
            this.albumRepository = albumRepository;
        }

        private async Task<bool> DeleterIsAlbumOwner(DeleteAlbumCommand deleteAlbumCommand, CancellationToken arg2)
        {
            return await albumRepository.IsAlbumOwnerAsync(deleteAlbumCommand.AlbumId, deleteAlbumCommand.DeleterId);
        }
    }
}
