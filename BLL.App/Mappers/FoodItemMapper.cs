using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class FoodItemMapper: BaseMapper<BLL.App.DTO.FoodItem, DAL.App.DTO.FoodItem>,IBaseMapper<BLL.App.DTO.FoodItem, DAL.App.DTO.FoodItem>
    {
        public FoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}