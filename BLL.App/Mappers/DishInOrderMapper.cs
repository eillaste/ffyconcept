using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class DishInOrderMapper: BaseMapper<BLL.App.DTO.DishInOrder, DAL.App.DTO.DishInOrder>,IBaseMapper<BLL.App.DTO.DishInOrder, DAL.App.DTO.DishInOrder>
    {
        public DishInOrderMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}