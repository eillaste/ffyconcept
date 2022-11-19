using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class RecipeTagMapper:BaseMapper<BLL.App.DTO.RecipeTag, DAL.App.DTO.RecipeTag>, IBaseMapper<BLL.App.DTO.RecipeTag, DAL.App.DTO.RecipeTag>
    {
        public RecipeTagMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}