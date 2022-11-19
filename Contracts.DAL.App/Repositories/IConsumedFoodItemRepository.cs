using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
//using Domain.App;
//using DTO.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IConsumedFoodItemRepository: IBaseRepository<ConsumedFoodItem>,IConsumedFoodItemRepositoryCustom<ConsumedFoodItem>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
        
    }
    

    public interface IConsumedFoodItemRepositoryCustom<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllWithFoodItemDateAndQuantityAsync(Guid userId, bool noTracking = true);
        Task<TEntity?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true);
    }
}