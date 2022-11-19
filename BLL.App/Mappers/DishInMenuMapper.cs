using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class DishInMenuMapper: BaseMapper<BLL.App.DTO.DishInMenu, DAL.App.DTO.DishInMenu>,IBaseMapper<BLL.App.DTO.DishInMenu, DAL.App.DTO.DishInMenu>
    {
        public DishInMenuMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}