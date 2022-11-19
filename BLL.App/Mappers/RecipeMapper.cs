using AutoMapper;
using Contracts.DAL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class RecipeMapper: BaseMapper<BLL.App.DTO.Recipe, DAL.App.DTO.Recipe>,IBaseMapper<BLL.App.DTO.Recipe, DAL.App.DTO.Recipe>
    {
        public RecipeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}