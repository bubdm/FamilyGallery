using MediatR;
using System;
using System.Collections.Generic;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbumWithFiles
{
    public class GetAlbumWithFilesQuery : IRequest<GetAlbumWithFilesQueryResponse>
    {
        public Guid UserId { get; set; }

        public Guid AlbumId { get; set; }

        public int NumberOfFiles { get; set; }

        public int Page { get; set; }
    }
}
