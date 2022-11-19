using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IRecipeTagRepository: IBaseRepository<RecipeTag>, IRecipeTagRepositoryCustom<RecipeTag>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IRecipeTagRepositoryCustom<TEntity>
    {
        
    }
}