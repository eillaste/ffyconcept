using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class ConsumedNutrientMapper: BaseMapper<DAL.App.DTO.ConsumedNutrient, Domain.App.ConsumedNutrient>,IBaseMapper<DAL.App.DTO.ConsumedNutrient, Domain.App.ConsumedNutrient>
    {
        public ConsumedNutrientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}