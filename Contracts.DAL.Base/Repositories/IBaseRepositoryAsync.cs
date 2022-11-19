using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain.Base;

namespace Contracts.DAL.Base.Repositories
{
    public interface IBaseRepositoryAsync<TEntity, TKey>: IBaseRepositoryCommon<TEntity, TKey> 
        where TEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {
        // CRUD methods async
        Task<IEnumerable<TEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true);
        Task<TEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default, bool noTracking = true); // FindOne is bad since no related entities included
        Task<bool> ExistsAsync(TKey id, TKey? userId = default);
        Task<TEntity> RemoveAsync(TKey id, TKey? userId = default);
    }
}