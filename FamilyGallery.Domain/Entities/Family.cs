using System;
using System.Collections.Generic;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    public class Family : AuditedEntity<Guid>
    {
        public string Name { get; set; }

        public int CreatorId { get; set; }

        public IReadOnlyList<User> Members { get; set; }
    }
}
