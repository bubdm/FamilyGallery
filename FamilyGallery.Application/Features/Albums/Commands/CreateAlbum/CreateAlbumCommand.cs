using MediatR;
using System;

namespace FamilyGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<CreateAlbumCommandResponse>
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public Guid CreatorId { get; set; }
    }
}
