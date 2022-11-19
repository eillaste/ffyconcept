using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class NutrientMapper: BaseMapper<BLL.App.DTO.Nutrient, DAL.App.DTO.Nutrient>,IBaseMapper<BLL.App.DTO.Nutrient, DAL.App.DTO.Nutrient>
    {
        public NutrientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}