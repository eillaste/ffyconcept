using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class StockMapper: BaseMapper<DAL.App.DTO.Stock, Domain.App.Stock>,IBaseMapper<DAL.App.DTO.Stock, Domain.App.Stock>
    {
        public StockMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}