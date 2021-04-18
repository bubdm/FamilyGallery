using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Persistence.EntityFramework.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly FamilyGalleryDbContext dbContext;

        public AlbumRepository(FamilyGalleryDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Album>> GetByFamilyAsync(Guid familyId)
        {
            var result = dbContext.Albums
                .Join(
                    dbContext.FamilyMembers,
                    album => album.CreatorId,
                    member => member.UserId,
                    (album, member) => new
                    {
                        Album = album,
                        FamilyId = member.FamilyId
                    }).Where(x => x.FamilyId == familyId)
                .Select(x => x.Album)
                .ToListAsync();

            return await result;
        }
    }
}
