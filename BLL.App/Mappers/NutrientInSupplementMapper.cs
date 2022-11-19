using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class NutrientInSupplementMapper:BaseMapper<BLL.App.DTO.NutrientInSupplement, DAL.App.DTO.NutrientInSupplement>, IBaseMapper<BLL.App.DTO.NutrientInSupplement, DAL.App.DTO.NutrientInSupplement>
    {
        public NutrientInSupplementMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}