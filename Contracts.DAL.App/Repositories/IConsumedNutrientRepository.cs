using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IConsumedNutrientRepository: IBaseRepository<ConsumedNutrient>, IConsumedNutrientRepositoryCustom<ConsumedNutrient>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IConsumedNutrientRepositoryCustom<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllWithNutrientDateAndQuantityAsync(Guid userId, bool noTracking = true);
        Task<TEntity?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true);

    }
}