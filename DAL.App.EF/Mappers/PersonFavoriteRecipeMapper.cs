using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonFavoriteRecipeMapper:BaseMapper<DAL.App.DTO.PersonFavoriteRecipe, Domain.App.PersonFavoriteRecipe>, IBaseMapper<DAL.App.DTO.PersonFavoriteRecipe, Domain.App.PersonFavoriteRecipe>
    {
        public PersonFavoriteRecipeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}