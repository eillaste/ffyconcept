using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonDietMapper: BaseMapper<BLL.App.DTO.PersonDiet, DAL.App.DTO.PersonDiet>,IBaseMapper<BLL.App.DTO.PersonDiet, DAL.App.DTO.PersonDiet>
    {
        public PersonDietMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}