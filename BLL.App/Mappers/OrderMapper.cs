using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class OrderMapper: BaseMapper<BLL.App.DTO.Order, DAL.App.DTO.Order>,IBaseMapper<BLL.App.DTO.Order, DAL.App.DTO.Order>
    {
        public OrderMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}