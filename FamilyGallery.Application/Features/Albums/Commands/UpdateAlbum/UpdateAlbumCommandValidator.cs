using FamilyGallery.Application.Contracts.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>
    {
        private readonly IAlbumRepository albumRepository;

        public UpdateAlbumCommandValidator(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
            RuleFor(a => a.Name).MaximumLength(50).WithMessage("Album name cannot exceed 50 characters");
            RuleFor(a => a.Name).MinimumLength(2).WithMessage("Album name must be 2 characters or more");
            RuleFor(a => a.Description).MaximumLength(50).WithMessage("Album name cannot exceed 500 characters");
            RuleFor(a => a).MustAsync(UpdaterIsAlbumOwner).WithMessage("An album can only be updated by it's owner");
        }

        private async Task<bool> UpdaterIsAlbumOwner(UpdateAlbumCommand updateAlbumCommand, CancellationToken arg2)
        {
            return await albumRepository.IsAlbumOwnerAsync(updateAlbumCommand.AlbumId, updateAlbumCommand.UpdaterId);
        }
    }
}
