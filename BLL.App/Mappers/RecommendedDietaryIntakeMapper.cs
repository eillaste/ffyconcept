using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class RecommendedDietaryIntakeMapper: BaseMapper<BLL.App.DTO.RecommendedDietaryIntake, DAL.App.DTO.RecommendedDietaryIntake>,IBaseMapper<BLL.App.DTO.RecommendedDietaryIntake, DAL.App.DTO.RecommendedDietaryIntake>
    {
        public RecommendedDietaryIntakeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}