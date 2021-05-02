using MediatR;
using System;

namespace FamilyGallery.Application.Features.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : IRequest<UpdateAlbumCommandResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid UpdaterId { get; set; }

        public Guid AlbumId { get; set; }
    }
}
