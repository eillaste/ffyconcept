using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TolerableUpperIntakeLevelMapper: BaseMapper<DAL.App.DTO.TolerableUpperIntakeLevel, Domain.App.TolerableUpperIntakeLevel>,IBaseMapper<DAL.App.DTO.TolerableUpperIntakeLevel, Domain.App.TolerableUpperIntakeLevel>
    {
        public TolerableUpperIntakeLevelMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}