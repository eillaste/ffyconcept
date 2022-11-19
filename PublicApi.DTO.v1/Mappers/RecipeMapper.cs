using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class RecipeMapper : BaseMapper<PublicApi.DTO.v1.Recipe, BLL.App.DTO.Recipe>
    {
        public RecipeMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Recipe MapToBll(RecipeAddPut recipeAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Recipe()
            {
                Id = recipeAdd.Id,
                AppUserId = recipeAdd.AppUserId,
                Description = recipeAdd.Description,
                Instructions = recipeAdd.Instructions,
                Servings = recipeAdd.Servings,
                PrepTime = recipeAdd.PrepTime,
                RestaurantRecipe = recipeAdd.RestaurantRecipe,
                Image = recipeAdd.Image
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}