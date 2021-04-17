using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Commands
{
    public class CreateFamilyCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
