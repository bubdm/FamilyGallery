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
    public class FamilyMemberRepository : BaseRepository<FamilyMember>, IFamilyMemberRepository
    {
        private readonly FamilyGalleryDbContext dbContext;

        public FamilyMemberRepository(FamilyGalleryDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyList<FamilyMember>> GetByFamily(Guid id)
        {
            return await dbContext.FamilyMembers.Where(x => x.FamilyId == id).ToListAsync();
        }

        public async Task<bool> IsFamilyMember(Guid familyId, Guid userId)
        {
            return await dbContext.FamilyMembers.AnyAsync(x => x.FamilyId == familyId && x.UserId == userId);
        }
    }
}
