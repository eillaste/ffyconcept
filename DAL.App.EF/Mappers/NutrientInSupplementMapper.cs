using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class NutrientInSupplementMapper:BaseMapper<DAL.App.DTO.NutrientInSupplement, Domain.App.NutrientInSupplement>, IBaseMapper<DAL.App.DTO.NutrientInSupplement, Domain.App.NutrientInSupplement>
    {
        public NutrientInSupplementMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}