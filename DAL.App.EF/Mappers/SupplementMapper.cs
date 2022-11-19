using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class SupplementMapper: BaseMapper<DAL.App.DTO.Supplement, Domain.App.Supplement>,IBaseMapper<DAL.App.DTO.Supplement, Domain.App.Supplement>
    {
        public SupplementMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}