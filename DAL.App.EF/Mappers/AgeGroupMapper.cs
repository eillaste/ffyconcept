using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class AgeGroupMapper : BaseMapper<DAL.App.DTO.AgeGroup, Domain.App.AgeGroup>, IBaseMapper<DAL.App.DTO.AgeGroup, Domain.App.AgeGroup>
    {
        public AgeGroupMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}