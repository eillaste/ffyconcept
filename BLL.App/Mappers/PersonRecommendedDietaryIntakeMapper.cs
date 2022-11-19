using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class PersonRecommendedDietaryIntakeMapper: BaseMapper<BLL.App.DTO.PersonRecommendedDietaryIntake, DAL.App.DTO.PersonRecommendedDietaryIntake>,IBaseMapper<BLL.App.DTO.PersonRecommendedDietaryIntake, DAL.App.DTO.PersonRecommendedDietaryIntake>
    {
        public PersonRecommendedDietaryIntakeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}