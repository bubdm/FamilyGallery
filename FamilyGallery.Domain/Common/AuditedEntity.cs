using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Domain.Common
{
    public class AuditedEntity<T> : Entity<T> where T : struct
    {
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
