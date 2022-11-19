using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class HealthSpecificationMapper: BaseMapper<BLL.App.DTO.HealthSpecification, DAL.App.DTO.HealthSpecification>,IBaseMapper<BLL.App.DTO.HealthSpecification, DAL.App.DTO.HealthSpecification>
    {
        public HealthSpecificationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}