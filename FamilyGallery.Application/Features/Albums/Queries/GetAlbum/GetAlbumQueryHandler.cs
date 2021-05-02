using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbum
{
    public class GetAlbumQueryHandler : IRequestHandler<GetAlbumQuery, GetAlbumQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;
        private readonly IAlbumMemberRepository albumMemberRepository;

        public GetAlbumQueryHandler(IMapper mapper, IAlbumRepository albumRepository, IAlbumMemberRepository albumMemberRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
            this.albumMemberRepository = albumMemberRepository;
        }

        public async Task<GetAlbumQueryResponse> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAlbumQueryValidator(albumRepository, albumMemberRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new GetAlbumQueryResponse { IsSuccessful = false, Message = validationResult.ToString() };
            }
            var album = await albumRepository.GetByIdAsync(request.AlbumId);
            return new GetAlbumQueryResponse { 
                IsSuccessful = true, 
                Data = mapper.Map<AlbumVm>(album)
            }; 
        }
    }
}
