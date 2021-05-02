using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands.DeleteFamily
{
    public class DeleteFamilyCommand : IRequest<DeleteFamilyCommandResponse>
    {
        public Guid FamilyId { get; set; }
        public Guid DeleterId { get; set; }
    }
}
