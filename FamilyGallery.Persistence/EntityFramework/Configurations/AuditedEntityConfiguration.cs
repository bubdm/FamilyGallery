using FamilyGallery.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Persistence.EntityFramework.Configurations
{
    public class AuditedEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : AuditedEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatorId).IsRequired();
            builder.Property(e => e.LastModifierId);
        }
    }
}
