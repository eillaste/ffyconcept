using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ConsumedFoodItemMapper: BaseMapper<DAL.App.DTO.ConsumedFoodItem, Domain.App.ConsumedFoodItem>,IBaseMapper<DAL.App.DTO.ConsumedFoodItem, Domain.App.ConsumedFoodItem>
    {
        public ConsumedFoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}