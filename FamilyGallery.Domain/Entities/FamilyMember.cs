using System;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    class FamilyMember : AuditedEntity<Guid>
    {
        public Guid FamilyId { get; set; }
        
        public Guid UserId { get; set; }
    }
}
