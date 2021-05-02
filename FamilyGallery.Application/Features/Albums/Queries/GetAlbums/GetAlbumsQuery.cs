using MediatR;
using System;
using System.Collections.Generic;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbums
{
    public class GetAlbumsQuery : IRequest<GetAlbumsQueryResponse>
    {
        public Guid UserId { get; set; }
    }
}
