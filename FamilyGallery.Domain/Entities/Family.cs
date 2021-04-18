
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    public class Family : AuditedEntity<Guid>, IEquatable<Family>
    {
        public Family()
        {
            Members = new List<User>();
        }
        public string Name { get; set; }

        public IReadOnlyList<User> Members { get; set; }

        public bool Equals([AllowNull] Family other)
        {
            return other != null && this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Family && Equals(obj);
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(Id.ToByteArray(), 0);
        }
    }
}
