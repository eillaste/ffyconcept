using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class NutrientInFoodItemMapper: BaseMapper<DAL.App.DTO.NutrientInFoodItem, Domain.App.NutrientInFoodItem>,IBaseMapper<DAL.App.DTO.NutrientInFoodItem, Domain.App.NutrientInFoodItem>
    {
        public NutrientInFoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}