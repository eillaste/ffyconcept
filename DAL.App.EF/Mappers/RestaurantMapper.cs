using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class RestaurantMapper: BaseMapper<DAL.App.DTO.Restaurant, Domain.App.Restaurant>,IBaseMapper<DAL.App.DTO.Restaurant, Domain.App.Restaurant>
    {
        public RestaurantMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}