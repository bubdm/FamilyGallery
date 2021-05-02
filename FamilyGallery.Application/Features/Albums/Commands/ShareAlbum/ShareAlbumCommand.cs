using FamilyGallery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.ShareAlbum
{
    public class ShareAlbumCommand : IRequest<ShareAlbumCommandResponse>
    {
        public Guid AlbumId { get; set; }

        public Guid ActorId { get; set; }

        public ShareWith ShareWith { get; set; }

        public List<Guid> UserIds{ get; set; }
    }
}
