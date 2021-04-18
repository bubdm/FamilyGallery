using FamilyGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Persistence.EntityFramework
{
    public class FamilyGalleryDbContext : DbContext
    {
        public FamilyGalleryDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Family> Families { get; set; }

        public DbSet<FamilyMember> FamilyMembers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<AlbumMember> AlbumMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FamilyGalleryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
