using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class AgeGroupMapper : BaseMapper<BLL.App.DTO.AgeGroup, DAL.App.DTO.AgeGroup>, IBaseMapper<BLL.App.DTO.AgeGroup, DAL.App.DTO.AgeGroup>
    {
        public AgeGroupMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}