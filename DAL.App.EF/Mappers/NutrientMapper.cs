using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class NutrientMapper: BaseMapper<DAL.App.DTO.Nutrient, Domain.App.Nutrient>,IBaseMapper<DAL.App.DTO.Nutrient, Domain.App.Nutrient>
    {
        public NutrientMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}