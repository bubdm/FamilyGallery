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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly FamilyGalleryDbContext dbContext;

        public UserRepository(FamilyGalleryDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> FindByEmail(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
