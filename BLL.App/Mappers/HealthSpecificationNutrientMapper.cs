using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class HealthSpecificationNutrientMapper: BaseMapper<BLL.App.DTO.HealthSpecificationNutrient, DAL.App.DTO.HealthSpecificationNutrient>,IBaseMapper<BLL.App.DTO.HealthSpecificationNutrient, DAL.App.DTO.HealthSpecificationNutrient>
    {
        public HealthSpecificationNutrientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}