using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonSupplementMapper: BaseMapper<BLL.App.DTO.PersonSupplement, DAL.App.DTO.PersonSupplement>,IBaseMapper<BLL.App.DTO.PersonSupplement, DAL.App.DTO.PersonSupplement>
    {
        public PersonSupplementMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}