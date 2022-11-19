using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class NutrientInFoodItemMapper: BaseMapper<BLL.App.DTO.NutrientInFoodItem, DAL.App.DTO.NutrientInFoodItem>,IBaseMapper<BLL.App.DTO.NutrientInFoodItem, DAL.App.DTO.NutrientInFoodItem>
    {
        public NutrientInFoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}