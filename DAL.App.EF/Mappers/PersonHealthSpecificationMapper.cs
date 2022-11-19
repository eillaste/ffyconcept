using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonHealthSpecificationMapper: BaseMapper<DAL.App.DTO.PersonHealthSpecification, Domain.App.PersonHealthSpecification>,IBaseMapper<DAL.App.DTO.PersonHealthSpecification, Domain.App.PersonHealthSpecification>
    {
        public PersonHealthSpecificationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}