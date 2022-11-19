using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class PersonRecommendedDietaryIntakeMapper: BaseMapper<DAL.App.DTO.PersonRecommendedDietaryIntake, Domain.App.PersonRecommendedDietaryIntake>,IBaseMapper<DAL.App.DTO.PersonRecommendedDietaryIntake, Domain.App.PersonRecommendedDietaryIntake>
    {
        public PersonRecommendedDietaryIntakeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}