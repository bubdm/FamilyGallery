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
    public class AuditedEntityConfiguration : IEntityTypeConfiguration<AuditedEntity>
    {
        public void Configure(EntityTypeBuilder<AuditedEntity> builder)
        {
            builder.Property(e => e.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastModifiedBy).HasMaxLength(50);
        }
    }
}
