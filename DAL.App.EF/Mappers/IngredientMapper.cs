using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class IngredientMapper: BaseMapper<DAL.App.DTO.Ingredient, Domain.App.Ingredient>,IBaseMapper<DAL.App.DTO.Ingredient, Domain.App.Ingredient>
    {
        public IngredientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}