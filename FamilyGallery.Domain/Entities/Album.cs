
using FamilyGallery.Domain.Common;
using System;
using System.Collections.Generic;

namespace FamilyGallery.Domain.Entities
{
    public class Album : AuditedEntity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public IReadOnlyCollection<File> Files { get; set; }

        public IReadOnlyCollection<AlbumMember> Members { get; set; }
    }
}
