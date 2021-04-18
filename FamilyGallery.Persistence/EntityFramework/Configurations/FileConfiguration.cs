using FamilyGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyGallery.Persistence.EntityFramework.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.Property(e => e.ContentType).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Extension).IsRequired().HasMaxLength(50);
            builder.Property(e => e.FileSize).IsRequired();
            builder.Property(e => e.Path).IsRequired().HasMaxLength(500);
            builder.Property(e => e.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastModifiedBy).HasMaxLength(50);
        }
    }
}
