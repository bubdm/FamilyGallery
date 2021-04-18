using FamilyGallery.Application.Contracts.Persistence;
using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Persistence.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FamilyGalleryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
