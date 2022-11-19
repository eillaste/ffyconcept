using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class IngredientMapper: BaseMapper<BLL.App.DTO.Ingredient, DAL.App.DTO.Ingredient>,IBaseMapper<BLL.App.DTO.Ingredient, DAL.App.DTO.Ingredient>
    {
        public IngredientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}