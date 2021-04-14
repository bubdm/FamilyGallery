using System;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    public class User : AuditedEntity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
