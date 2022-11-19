using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DishInMenuMapper: BaseMapper<DAL.App.DTO.DishInMenu, Domain.App.DishInMenu>,IBaseMapper<DAL.App.DTO.DishInMenu, Domain.App.DishInMenu>
    {
        public DishInMenuMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}