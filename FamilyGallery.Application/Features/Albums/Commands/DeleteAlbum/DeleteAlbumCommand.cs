using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommand : IRequest<DeleteAlbumCommandResponse>
    {
        public Guid AlbumId { get; set; }
        public Guid DeleterId { get; set; }
    }
}
