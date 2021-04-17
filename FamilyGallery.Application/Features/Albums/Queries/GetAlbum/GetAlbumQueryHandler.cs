using AutoMapper;
using FamilyGallery.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbum
{
    public class GetAlbumQueryHandler : IRequestHandler<GetAlbumQuery, AlbumVm>
    {
        private readonly IMapper mapper;
        private readonly IAlbumRepository albumRepository;

        public GetAlbumQueryHandler(IMapper mapper, IAlbumRepository albumRepository)
        {
            this.mapper = mapper;
            this.albumRepository = albumRepository;
        }

        public async Task<AlbumVm> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            var album = await albumRepository.GetByIdAsync(request.Id);
            return mapper.Map<AlbumVm>(album);
        }
    }
}
