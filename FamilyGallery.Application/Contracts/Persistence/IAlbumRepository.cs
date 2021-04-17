using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Persistence
{
    public interface IAlbumRepository : IAsyncRepository<Album, Guid>
    {
        Task<ICollection<Album>> GetByFamilyAsync(Guid familyId);
    }
}
