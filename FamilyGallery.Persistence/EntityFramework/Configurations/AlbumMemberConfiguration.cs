using FamilyGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyGallery.Persistence.EntityFramework.Configurations
{
    public class AlbumMemberConfiguration : IEntityTypeConfiguration<AlbumMember>
    {
        public void Configure(EntityTypeBuilder<AlbumMember> builder)
        {
            builder.Property(e => e.AlbumId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
        }
    }
}
