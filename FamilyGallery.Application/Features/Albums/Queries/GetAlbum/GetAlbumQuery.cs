using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Queries.GetAlbum
{
    public class GetAlbumQuery : IRequest<AlbumVm>
    {
        public Guid Id { get; set; }
    }
}
