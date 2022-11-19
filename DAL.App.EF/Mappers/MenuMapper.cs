using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class MenuMapper: BaseMapper<DAL.App.DTO.Menu, Domain.App.Menu>,IBaseMapper<DAL.App.DTO.Menu, Domain.App.Menu>
    {
        public MenuMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}