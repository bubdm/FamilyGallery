using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbums
{
    public class GetAlbumsQueryHandler : IRequestHandler<GetAlbumsQuery, List<AlbumVm>>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;
        private readonly IMediaRepository mediaRepository;

        public GetAlbumsQueryHandler(IMapper mapper, IAlbumRepository albumRepository, IMediaRepository mediaRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
            this.mediaRepository = mediaRepository;
        }
        public async Task<List<AlbumVm>> Handle(GetAlbumsQuery request, CancellationToken cancellationToken)
        {
            var albums = await albumRepository.GetByFamilyAsync(request.Id);
            return mapper.Map<List<AlbumVm>>(albums);
        }
    }
}
