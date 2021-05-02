using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.UnshareAlbum
{
    public class UnshareAlbumCommandValidator : AbstractValidator<UnshareAlbumCommand>
    {
        private readonly IAlbumRepository albumRepository;

        public UnshareAlbumCommandValidator(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
            RuleFor(r => r).MustAsync(IsOwner).WithMessage("Only the owner can unshare an album");
        }

        private async Task<bool> IsOwner(UnshareAlbumCommand command, CancellationToken token)
        {
            return await albumRepository.IsAlbumOwnerAsync(command.AlbumId, command.ActorId);
        }
    }
}
