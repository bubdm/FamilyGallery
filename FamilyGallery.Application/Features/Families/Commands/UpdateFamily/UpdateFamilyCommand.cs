using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommand : IRequest<UpdateFamilyCommandResponse>
    {
        public Guid Id { get; set; }

        public Guid UpdaterId { get; set; }
        
        public string Name { get; set; }
    }
}
