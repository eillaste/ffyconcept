using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class TolerableUpperIntakeLevelMapper: BaseMapper<BLL.App.DTO.TolerableUpperIntakeLevel, DAL.App.DTO.TolerableUpperIntakeLevel>,IBaseMapper<BLL.App.DTO.TolerableUpperIntakeLevel, DAL.App.DTO.TolerableUpperIntakeLevel>
    {
        public TolerableUpperIntakeLevelMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}