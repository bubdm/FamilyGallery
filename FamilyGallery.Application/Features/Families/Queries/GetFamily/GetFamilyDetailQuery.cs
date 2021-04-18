using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.GetFamily
{
    public class GetFamilyQuery : IRequest<FamilyVm>
    {
        public Guid Id { get; set; }
    }
}
