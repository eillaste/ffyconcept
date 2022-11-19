using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class TagMapper: BaseMapper<BLL.App.DTO.Tag, DAL.App.DTO.Tag>,IBaseMapper<BLL.App.DTO.Tag, DAL.App.DTO.Tag>
    {
        public TagMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}