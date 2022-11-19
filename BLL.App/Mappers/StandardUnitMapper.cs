using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class StandardUnitMapper: BaseMapper<BLL.App.DTO.StandardUnit, DAL.App.DTO.StandardUnit>,IBaseMapper<BLL.App.DTO.StandardUnit, DAL.App.DTO.StandardUnit>
    {
        public StandardUnitMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}