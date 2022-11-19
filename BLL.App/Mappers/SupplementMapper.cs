using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class SupplementMapper: BaseMapper<BLL.App.DTO.Supplement, DAL.App.DTO.Supplement>,IBaseMapper<BLL.App.DTO.Supplement, DAL.App.DTO.Supplement>
    {
        public SupplementMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}