using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families
{
    public class GetFamiliesListQuery : IRequest<List<FamilyListVm>>
    {
    }
}
