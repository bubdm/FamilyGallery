using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Persistence
{
    public interface IAsyncUserRepository : IAsyncRepository<User, Guid>
    {
    }
}
