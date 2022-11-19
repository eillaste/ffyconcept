using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DietaryRestrictionMapper: BaseMapper<DAL.App.DTO.DietaryRestriction, Domain.App.DietaryRestriction>,IBaseMapper<DAL.App.DTO.DietaryRestriction, Domain.App.DietaryRestriction>
    {
        public DietaryRestrictionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}