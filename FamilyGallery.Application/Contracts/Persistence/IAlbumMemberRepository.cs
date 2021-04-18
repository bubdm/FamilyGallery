using FamilyGallery.Domain.Entities;
using System;

namespace FamilyGallery.Application.Contracts.Persistence
{
    public interface IAlbumMemberRepository : IAsyncRepository<AlbumMember>
    {
    }
}
