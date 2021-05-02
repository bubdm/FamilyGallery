using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;

        public CreateAlbumCommandHandler(IMapper mapper, IAlbumRepository albumRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
        }

        public async Task<CreateAlbumCommandResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAlbumCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new CreateAlbumCommandResponse {
                    IsSuccessful = false,
                    Message = validationResult.ToString()
                };
            }
            var album = mapper.Map<Album>(request);
            album = await albumRepository.AddAsync(album);
            return new CreateAlbumCommandResponse { IsSuccessful = true, Data = mapper.Map<AlbumVm>(album) };
        }
    }
}
