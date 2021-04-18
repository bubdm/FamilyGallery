using FamilyGallery.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Domain.Entities
{
    public class AlbumMember : AuditedEntity<Guid>, IEquatable<AlbumMember>
    {
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool Equals([AllowNull] AlbumMember other)
        {
            return other != null && other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            return obj is AlbumMember && Equals(obj);
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(Id.ToByteArray());
        }
    }
}
