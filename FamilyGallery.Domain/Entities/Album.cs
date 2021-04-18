
using FamilyGallery.Domain.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FamilyGallery.Domain.Entities
{
    public class Album : AuditedEntity<Guid>, IEquatable<Album>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public IReadOnlyCollection<File> Files { get; set; }

        public IReadOnlyCollection<AlbumMember> Members { get; set; }

        public bool Equals([AllowNull] Album other)
        {
            return other != null && other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Album && Equals(obj);
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(Id.ToByteArray(),0);
        }
    }
}
