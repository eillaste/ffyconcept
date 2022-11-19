using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class TagMapper: BaseMapper<DAL.App.DTO.Tag, Domain.App.Tag>,IBaseMapper<DAL.App.DTO.Tag, Domain.App.Tag>
    {
        public TagMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}