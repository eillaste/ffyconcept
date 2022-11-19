using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class StockMapper: BaseMapper<BLL.App.DTO.Stock, DAL.App.DTO.Stock>,IBaseMapper<BLL.App.DTO.Stock, DAL.App.DTO.Stock>
    {
        public StockMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}