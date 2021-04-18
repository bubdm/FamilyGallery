using FamilyGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyGallery.Persistence.EntityFramework.Configurations
{
    public class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
    {
        public void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            builder.Property(e => e.FamilyId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
        }
    }
}
