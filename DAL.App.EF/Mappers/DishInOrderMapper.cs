using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DishInOrderMapper: BaseMapper<DAL.App.DTO.DishInOrder, Domain.App.DishInOrder>,IBaseMapper<DAL.App.DTO.DishInOrder, Domain.App.DishInOrder>
    {
        public DishInOrderMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}