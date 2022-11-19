using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class FoodItemMapper: BaseMapper<DAL.App.DTO.FoodItem, Domain.App.FoodItem>,IBaseMapper<DAL.App.DTO.FoodItem, Domain.App.FoodItem>
    {
        public FoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}