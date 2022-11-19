using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ConsumedNutrientMapper: BaseMapper<BLL.App.DTO.ConsumedNutrient, DAL.App.DTO.ConsumedNutrient>,IBaseMapper<BLL.App.DTO.ConsumedNutrient, DAL.App.DTO.ConsumedNutrient>
    {
        public ConsumedNutrientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}