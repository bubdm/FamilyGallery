using FamilyGallery.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyGallery.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : AuditedEntity
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
