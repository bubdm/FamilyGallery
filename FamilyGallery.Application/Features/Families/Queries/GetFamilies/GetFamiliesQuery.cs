using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families.Queries.GetFamilies
{
    public class GetFamiliesQuery : IRequest<List<FamilyVm>>
    {
        public Guid UserId { get; set; }
    }
}
