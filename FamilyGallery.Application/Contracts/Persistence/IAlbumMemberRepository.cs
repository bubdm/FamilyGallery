using FamilyGallery.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Persistence
{
    public interface IAlbumMemberRepository : IAsyncRepository<AlbumMember>
    {
        Task<bool> IsAlbumMember(Guid albumId, Guid userId);
        Task DeleteByAlbumId(Guid albumId);
    }
}
