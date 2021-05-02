using MediatR;
using System;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbum
{
    public class GetAlbumQuery : IRequest<GetAlbumQueryResponse>
    {
        public Guid AlbumId { get; set; }

        public Guid UserId { get; set; }
    }
}
