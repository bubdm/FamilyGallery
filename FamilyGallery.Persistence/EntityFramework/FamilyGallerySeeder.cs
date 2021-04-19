using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Persistence.EntityFramework
{
    public class FamilyGallerySeeder
    {
        private readonly FamilyGalleryDbContext context;

        public FamilyGallerySeeder(FamilyGalleryDbContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();
            if (!context.Families.Any())
            {
                //seed families                
            }
        }
    }
}
