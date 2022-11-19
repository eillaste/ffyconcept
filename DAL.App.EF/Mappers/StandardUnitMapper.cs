using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class StandardUnitMapper: BaseMapper<DAL.App.DTO.StandardUnit, Domain.App.StandardUnit>,IBaseMapper<DAL.App.DTO.StandardUnit, Domain.App.StandardUnit>
    {
        public StandardUnitMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}