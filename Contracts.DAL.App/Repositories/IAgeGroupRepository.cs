using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

/*using DALAppDTO = DAL.App.DTO;/*#1#*/
//using Domain.App;


namespace Contracts.DAL.App.Repositories
{
    public interface IAgeGroupRepository: IBaseRepository<AgeGroup>, IAgeGroupRepositoryCustom<AgeGroup>
    {
    }

    public interface IAgeGroupRepositoryCustom<TEntity>
    {
                Task<IEnumerable<TEntity>> GetAllWithRangeAsync(bool noTracking = true);
                Task<TEntity?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true);
    }
    
}