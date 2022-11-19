using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class RestaurantMapper: BaseMapper<BLL.App.DTO.Restaurant, DAL.App.DTO.Restaurant>,IBaseMapper<BLL.App.DTO.Restaurant, DAL.App.DTO.Restaurant>
    {
        public RestaurantMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}