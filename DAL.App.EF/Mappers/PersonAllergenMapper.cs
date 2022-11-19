using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonAllergenMapper: BaseMapper<DAL.App.DTO.PersonAllergen, Domain.App.PersonAllergen>,IBaseMapper<DAL.App.DTO.PersonAllergen, Domain.App.PersonAllergen>
    {
        public PersonAllergenMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}