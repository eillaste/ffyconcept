using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain.Base;

namespace Contracts.DAL.Base.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity: class, IDomainEntityId<Guid>
    {
        /*Task<IEnumerable<TEntity>> GetAllAsyncNoGuid();*/
    }
    
    public interface IBaseRepository<TEntity, TKey> :IBaseRepositoryAsync<TEntity, TKey>
        where TEntity: class, IDomainEntityId<TKey>
        where TKey: IEquatable<TKey>
    {

    }
}