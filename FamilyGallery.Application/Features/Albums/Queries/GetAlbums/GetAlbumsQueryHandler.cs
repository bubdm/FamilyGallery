using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbums
{
    public class GetAlbumsQueryHandler : IRequestHandler<GetAlbumsQuery, GetAlbumsQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;
        private readonly IFileRepository mediaRepository;

        public GetAlbumsQueryHandler(IMapper mapper, IAlbumRepository albumRepository, IFileRepository mediaRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
            this.mediaRepository = mediaRepository;
        }
        public async Task<GetAlbumsQueryResponse> Handle(GetAlbumsQuery request, CancellationToken cancellationToken)
        {
            //todo:validate
            var albums = await albumRepository.GetByOwnerAsync(request.UserId);
            return new GetAlbumsQueryResponse {
                IsSuccessful = true,
                Data = mapper.Map<List<AlbumVm>>(albums)
            };            
        }
    }
}
