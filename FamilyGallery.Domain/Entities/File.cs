using System;
using FamilyGallery.Domain.Common;

namespace FamilyGallery.Domain.Entities
{
    public class File : AuditedEntity<Guid>
    {
        public string Path { get; set; }

        public string ContentType { get; set; }

        public string Extension { get; set; }

        public Int64 FileSize { get; set; }

    }
}
