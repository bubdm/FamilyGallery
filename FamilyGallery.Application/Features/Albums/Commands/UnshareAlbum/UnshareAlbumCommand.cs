using FamilyGallery.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace FamilyGallery.Application.Features.Albums.Commands.UnshareAlbum
{
    public class UnshareAlbumCommand : IRequest<UnshareAlbumCommandResponse>
    {
        public Guid ActorId { get; set; }

        public Guid AlbumId { get; set; }

        public ShareWith ShareWith { get; set; }

        public List<Guid> FamilyOrUserIds { get; set; }
    }
}
