using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class StateMapper: BaseMapper<BLL.App.DTO.State, DAL.App.DTO.State>,IBaseMapper<BLL.App.DTO.State, DAL.App.DTO.State>
    {
        public StateMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}