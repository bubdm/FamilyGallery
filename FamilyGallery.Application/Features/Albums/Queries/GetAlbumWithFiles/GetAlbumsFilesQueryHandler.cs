using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbumWithFiles
{
    public class GetAlbumWithFilesQueryHandler : IRequestHandler<GetAlbumWithFilesQuery, GetAlbumWithFilesQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;
        private readonly IFileRepository mediaRepository;

        public GetAlbumWithFilesQueryHandler(IMapper mapper, IAlbumRepository albumRepository, IFileRepository mediaRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
            this.mediaRepository = mediaRepository;
        }
        public async Task<GetAlbumWithFilesQueryResponse> Handle(GetAlbumWithFilesQuery request, CancellationToken cancellationToken)
        {
            var album = await albumRepository.GetWithFilesAsync(request.AlbumId, request.NumberOfFiles, request.Page);
            return new GetAlbumWithFilesQueryResponse { 
                IsSuccessful = true,
                Data = mapper.Map<AlbumVm>(album)
            };            
        }
    }
}
