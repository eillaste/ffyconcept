using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ConsumedFoodItemMapper: BaseMapper<BLL.App.DTO.ConsumedFoodItem, DAL.App.DTO.ConsumedFoodItem>,IBaseMapper<BLL.App.DTO.ConsumedFoodItem, DAL.App.DTO.ConsumedFoodItem>
    {
        public ConsumedFoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}