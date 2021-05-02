using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Application.Exceptions;
using FamilyGallery.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, UpdateAlbumCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;

        public UpdateAlbumCommandHandler(IMapper mapper, IAlbumRepository albumRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
        }

        public async Task<UpdateAlbumCommandResponse> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAlbumCommandValidator(albumRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new UpdateAlbumCommandResponse { IsSuccessful = true, Message = validationResult.ToString() };
            }
            var album = await albumRepository.GetByIdAsync(request.AlbumId);
            album = mapper.Map<Album>(request);
            await albumRepository.UpdateAsync(album);
            return new UpdateAlbumCommandResponse { IsSuccessful=true };
        }
    }
}
