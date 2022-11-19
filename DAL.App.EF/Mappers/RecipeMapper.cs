using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class RecipeMapper: BaseMapper<DAL.App.DTO.Recipe, Domain.App.Recipe>,IBaseMapper<DAL.App.DTO.Recipe, Domain.App.Recipe>
    {
        public RecipeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}