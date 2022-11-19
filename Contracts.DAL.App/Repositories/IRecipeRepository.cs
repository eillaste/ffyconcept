using System;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IRecipeRepository: IBaseRepository<Recipe>, IRecipeRepositoryCustom<Recipe>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IRecipeRepositoryCustom<TEntity>
    {
        Task<TEntity?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true);
    }
}