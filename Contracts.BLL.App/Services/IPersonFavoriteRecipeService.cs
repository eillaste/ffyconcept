using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IPersonFavoriteRecipeService : IBaseEntityService<BLLAppDTO.PersonFavoriteRecipe,DALAppDTO.PersonFavoriteRecipe>, IPersonFavoriteRecipeRepositoryCustom<BLLAppDTO.PersonFavoriteRecipe>
    {
        
    }
}