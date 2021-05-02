using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.ShareAlbum
{
    public class ShareAlbumCommandValidator : AbstractValidator<ShareAlbumCommand>
    {
        private readonly IAlbumRepository albumRepository;

        public ShareAlbumCommandValidator(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
            RuleFor(r => r).Must(ProvidedIds).WithMessage("Family or Album members not specified");
            RuleFor(r => r).MustAsync(IsOwner).WithMessage("Only the owner can share an album");
        }

        private async Task<bool> IsOwner(ShareAlbumCommand command, CancellationToken cancellationToken)
        {
            return await albumRepository.IsAlbumOwnerAsync(command.AlbumId, command.ActorId);
        }

        private bool ProvidedIds(ShareAlbumCommand shareAlbumCommand)
        {
            return (shareAlbumCommand.ShareWith is ShareWith.Family or ShareWith.AlbumMembers) && shareAlbumCommand.UserIds.Count > 0;
        }
    }
}
