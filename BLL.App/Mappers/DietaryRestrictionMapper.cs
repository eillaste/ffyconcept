using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class DietaryRestrictionMapper: BaseMapper<BLL.App.DTO.DietaryRestriction, DAL.App.DTO.DietaryRestriction>,IBaseMapper<BLL.App.DTO.DietaryRestriction, DAL.App.DTO.DietaryRestriction>
    {
        public DietaryRestrictionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}