using FamilyGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyGallery.Persistence.EntityFramework.Configurations
{
    public class FamilyMemberConfiguration : AuditedEntityConfiguration<FamilyMember>, IEntityTypeConfiguration<FamilyMember>
    {
        public void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasAlternateKey(e => new { e.FamilyId, e.UserId });
            builder.Property(e => e.FamilyId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            base.Configure(builder);
        }
    }
}
