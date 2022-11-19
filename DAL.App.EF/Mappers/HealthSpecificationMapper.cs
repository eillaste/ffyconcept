using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class HealthSpecificationMapper: BaseMapper<DAL.App.DTO.HealthSpecification, Domain.App.HealthSpecification>,IBaseMapper<DAL.App.DTO.HealthSpecification, Domain.App.HealthSpecification>
    {
        public HealthSpecificationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}