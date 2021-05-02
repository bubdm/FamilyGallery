using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Files.Queries.GetFile
{
    public class GetFileQuery : IRequest<GetFileQueryResponse>
    {
        public Guid FileId { get; set; }

        public Guid AlbumId { get; set; }

        public Guid UserId { get; set; }
    }
}
