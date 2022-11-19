using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DietMapper: BaseMapper<DAL.App.DTO.Diet, Domain.App.Diet>,IBaseMapper<DAL.App.DTO.Diet, Domain.App.Diet>
    {
        public DietMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}