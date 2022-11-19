using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class MenuMapper: BaseMapper<BLL.App.DTO.Menu, DAL.App.DTO.Menu>,IBaseMapper<BLL.App.DTO.Menu, DAL.App.DTO.Menu>
    {
        public MenuMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}