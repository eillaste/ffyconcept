using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonFavoriteRecipeRepository: IBaseRepository<PersonFavoriteRecipe>, IPersonFavoriteRecipeRepositoryCustom<PersonFavoriteRecipe>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IPersonFavoriteRecipeRepositoryCustom<TEntity>
    {
        
    }
}