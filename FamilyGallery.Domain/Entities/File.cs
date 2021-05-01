using System;
using System.Diagnostics.CodeAnalysis;
using FamilyGallery.Domain.Common;

namespace FamilyGallery.Domain.Entities
{
    public class File : AuditedEntity, IEquatable<File>
    {
        public Guid AlbumId { get; set; }

        public string Path { get; set; }

        public string ContentType { get; set; }

        public string Extension { get; set; }

        public Int64 FileSize { get; set; }

        public bool Equals([AllowNull] File other)
        {
            return other != null && other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            return obj is File && Equals(obj);
        }

        public override int GetHashCode()
        {
            return BitConverter.ToInt32(Id.ToByteArray());
        }
    }


}
