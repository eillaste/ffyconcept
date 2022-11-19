using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class RecipeTagMapper:BaseMapper<DAL.App.DTO.RecipeTag, Domain.App.RecipeTag>, IBaseMapper<DAL.App.DTO.RecipeTag, Domain.App.RecipeTag>
    {
        public RecipeTagMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}