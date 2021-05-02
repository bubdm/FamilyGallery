using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.ShareAlbum
{
    public class ShareAlbumCommandHandler : IRequestHandler<ShareAlbumCommand, ShareAlbumCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;
        private readonly IAlbumMemberRepository albumMemberRepository;

        public ShareAlbumCommandHandler(IMapper mapper, IAlbumRepository albumRepository, IAlbumMemberRepository albumMemberRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
            this.albumMemberRepository = albumMemberRepository;
        }

        public async Task<ShareAlbumCommandResponse> Handle(ShareAlbumCommand request, CancellationToken cancellationToken)
        {
            var validator = new ShareAlbumCommandValidator(albumRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new ShareAlbumCommandResponse { IsSuccessful = false, Message = validationResult.ToString() };
            }
            if (request.ShareWith == Domain.Entities.ShareWith.AlbumMembers)
            {
                await UpdateAlbumMembership(request);
            }
            var album = await albumRepository.GetByIdAsync(request.AlbumId);
            album.ShareWith = request.ShareWith;
            await albumRepository.UpdateAsync(album);
            return new ShareAlbumCommandResponse { Data = mapper.Map<AlbumVm>(album), IsSuccessful=true };
        }

        private async Task UpdateAlbumMembership(ShareAlbumCommand request)
        {
            var list = request.UserIds.Select(
                id => new AlbumMember
                {
                    AlbumId = request.AlbumId,
                    UserId = id
                }
            );
            _ = await albumMemberRepository.AddAsync(list);
        }
    }
}
