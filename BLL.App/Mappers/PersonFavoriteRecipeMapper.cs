using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonFavoriteRecipeMapper:BaseMapper<BLL.App.DTO.PersonFavoriteRecipe, DAL.App.DTO.PersonFavoriteRecipe>, IBaseMapper<BLL.App.DTO.PersonFavoriteRecipe, DAL.App.DTO.PersonFavoriteRecipe>
    {
        public PersonFavoriteRecipeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}