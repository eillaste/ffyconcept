using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class RecommendedDietaryIntakeMapper: BaseMapper<DAL.App.DTO.RecommendedDietaryIntake, Domain.App.RecommendedDietaryIntake>,IBaseMapper<DAL.App.DTO.RecommendedDietaryIntake, Domain.App.RecommendedDietaryIntake>
    {
        public RecommendedDietaryIntakeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}