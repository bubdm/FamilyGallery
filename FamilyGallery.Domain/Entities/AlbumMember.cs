using FamilyGallery.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Domain.Entities
{
    public class AlbumMember : AuditedEntity<Guid>
    {
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
