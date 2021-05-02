using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Persistence
{
    public interface IFileRepository : IAsyncRepository<File>
    {
        Task<bool> IsOwner(Guid fileId, Guid userId);
    }
}
