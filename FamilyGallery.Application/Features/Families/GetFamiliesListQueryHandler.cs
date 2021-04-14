using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Features.Families
{
    public class GetFamiliesListQueryHandler : IRequestHandler<GetFamiliesListQuery, List<FamilyListVm>>
    {
        public Task<List<FamilyListVm>> Handle(GetFamiliesListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
