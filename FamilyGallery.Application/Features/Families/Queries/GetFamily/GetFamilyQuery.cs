using MediatR;
using System;

namespace FamilyGallery.Application.Features.Families.Queries.GetFamily
{
    public class GetFamilyQuery : IRequest<FamilyVm>
    {
        public Guid FamilyId { get; set; }
        public Guid UserId { get; set; }
    }
}
