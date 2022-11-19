using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonSupplementMapper: BaseMapper<DAL.App.DTO.PersonSupplement, Domain.App.PersonSupplement>,IBaseMapper<DAL.App.DTO.PersonSupplement, Domain.App.PersonSupplement>
    {
        public PersonSupplementMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}