using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class HealthSpecificationNutrientMapper: BaseMapper<DAL.App.DTO.HealthSpecificationNutrient, Domain.App.HealthSpecificationNutrient>,IBaseMapper<DAL.App.DTO.HealthSpecificationNutrient, Domain.App.HealthSpecificationNutrient>
    {
        public HealthSpecificationNutrientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}