using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class DietMapper: BaseMapper<BLL.App.DTO.Diet, DAL.App.DTO.Diet>,IBaseMapper<BLL.App.DTO.Diet, DAL.App.DTO.Diet>
    {
        public DietMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}