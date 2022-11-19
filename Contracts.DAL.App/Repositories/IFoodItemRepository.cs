using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
//using Domain.App;
//using DTO.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IFoodItemRepository: IBaseRepository<FoodItem>, IFoodItemRepositoryCustom<FoodItem>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
        
    }

    public interface IFoodItemRepositoryCustom<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllWithCountsAsync(bool noTracking = true);
    }
}