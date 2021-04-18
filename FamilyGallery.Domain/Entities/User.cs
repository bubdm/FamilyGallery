using System;
using System.Diagnostics.CodeAnalysis;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    public class User : AuditedEntity<Guid>, IEquatable<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Equals([AllowNull] User other)
        {
            return other != null && other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            return obj is User && Equals(obj);
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(Id.ToByteArray());
        }
    }
}
