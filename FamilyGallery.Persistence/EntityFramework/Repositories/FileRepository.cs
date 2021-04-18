using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Persistence.EntityFramework.Repositories
{
    public class FileRepository : BaseRepository<File>, IFileRepository
    {
        public FileRepository(FamilyGalleryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
