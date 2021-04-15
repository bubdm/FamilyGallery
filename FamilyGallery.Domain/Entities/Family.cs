
using System;
using System.Collections.Generic;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    public class Family : AuditedEntity<Guid>
    {
        public Family()
        {
            Members = new List<User>();
        }
        public string Name { get; set; }

        public IReadOnlyList<User> Members { get; set; }
    }
}
