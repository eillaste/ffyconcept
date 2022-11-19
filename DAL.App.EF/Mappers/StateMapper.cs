using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class StateMapper: BaseMapper<DAL.App.DTO.State, Domain.App.State>,IBaseMapper<DAL.App.DTO.State, Domain.App.State>
    {
        public StateMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}