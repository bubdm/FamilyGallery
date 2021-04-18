using System;
using System.Diagnostics.CodeAnalysis;
using FamilyGallery.Domain.Common;


namespace FamilyGallery.Domain.Entities
{
    public class FamilyMember : AuditedEntity, IEquatable<FamilyMember>
    {
        public Guid FamilyId { get; set; }
        
        public Guid UserId { get; set; }

        public Family Family { get; set; }
        
        public User User { get; set; }

        public bool Equals([AllowNull] FamilyMember other)
        {
            return other != null && other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            return obj is FamilyMember && Equals(obj);
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(Id.ToByteArray());
        }
    }
}
