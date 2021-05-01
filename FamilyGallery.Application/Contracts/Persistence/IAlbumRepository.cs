using FamilyGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Persistence
{
    public interface IAlbumRepository : IAsyncRepository<Album>
    {
        Task<ICollection<Album>> GetByFamilyAsync(Guid familyId);
        Task<ICollection<Album>> GetByOwnerAsync(Guid userId);

        Task<bool> IsAlbumOwnerAsync(Guid albumId, Guid userId);
        Task<Album> GetWithFilesAsync(Guid albumId, int numberOfFiles, int page);
    }
}
