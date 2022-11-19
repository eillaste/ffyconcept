using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonHealthSpecificationMapper: BaseMapper<BLL.App.DTO.PersonHealthSpecification, DAL.App.DTO.PersonHealthSpecification>,IBaseMapper<BLL.App.DTO.PersonHealthSpecification, DAL.App.DTO.PersonHealthSpecification>
    {
        public PersonHealthSpecificationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}