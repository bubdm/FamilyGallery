using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.UnshareAlbum
{
    public class UnshareAlbumCommandHandler : IRequestHandler<UnshareAlbumCommand, UnshareAlbumCommandResponse>
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;
        private readonly IAlbumMemberRepository albumMemberRepository;

        public UnshareAlbumCommandHandler(IAlbumRepository albumRepository, IMapper mapper, IAlbumMemberRepository albumMemberRepository)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
            this.albumMemberRepository = albumMemberRepository;
        }

        public async Task<UnshareAlbumCommandResponse> Handle(UnshareAlbumCommand request, CancellationToken cancellationToken)
        {
            var response = new UnshareAlbumCommandResponse();
            var validator = new UnshareAlbumCommandValidator(albumRepository);
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                response.Message = validationResult.ToString();
                return response;
            }
            var album = await albumRepository.GetByIdAsync(request.AlbumId);
            album.ShareWith = request.ShareWith;
            if (album.ShareWith == Domain.Entities.ShareWith.Nobody)
            {
                await albumMemberRepository.DeleteByAlbumId(request.AlbumId);
            }
            response.IsSuccessful = true;
            return response;
        }
    }
}
