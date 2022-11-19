using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonAllergenMapper: BaseMapper<BLL.App.DTO.PersonAllergen, DAL.App.DTO.PersonAllergen>,IBaseMapper<BLL.App.DTO.PersonAllergen, DAL.App.DTO.PersonAllergen>
    {
        public PersonAllergenMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}