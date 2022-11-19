using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class RecipeTagMapper : BaseMapper<PublicApi.DTO.v1.RecipeTag, BLL.App.DTO.RecipeTag>
    {
        public RecipeTagMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.RecipeTag MapToBll(RecipeTagAddPut recipeTagAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.RecipeTag()
            {

            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}