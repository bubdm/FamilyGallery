using FamilyGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyGallery.Persistence.EntityFramework.Configurations
{
    public class AlbumMemberConfiguration : AuditedEntityConfiguration<AlbumMember>, IEntityTypeConfiguration<AlbumMember>
    {
        public void Configure(EntityTypeBuilder<AlbumMember> builder)
        {
            builder.HasKey(e => e.Id); 
            builder.HasAlternateKey(e => new { e.AlbumId, e.UserId } );
            builder.Property(e => e.AlbumId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            base.Configure(builder);
        }
    }
}
