using System;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    public class FamilyMember : AuditedEntity<Guid>
    {
        public Guid FamilyId { get; set; }
        
        public Guid UserId { get; set; }

        public Family Family { get; set; }
        
        public User User { get; set; }
    }
}
