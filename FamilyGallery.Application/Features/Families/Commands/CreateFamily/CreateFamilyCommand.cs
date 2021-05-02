using FamilyGallery.Application.Features.Families.Commands.CreateFamily;
using MediatR;
using System;

namespace FamilyGallery.Application.Features.Families.Commands
{
    public class CreateFamilyCommand : IRequest<CreateFamilyCommandResponse>
    {
        public string Name { get; set; }

        public Guid CreatorId { get; set; }
    }
}
