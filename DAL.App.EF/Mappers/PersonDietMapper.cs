using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonDietMapper: BaseMapper<DAL.App.DTO.PersonDiet, Domain.App.PersonDiet>,IBaseMapper<DAL.App.DTO.PersonDiet, Domain.App.PersonDiet>
    {
        public PersonDietMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}