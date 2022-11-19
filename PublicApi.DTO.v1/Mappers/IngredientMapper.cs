using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class IngredientMapper : BaseMapper<PublicApi.DTO.v1.Ingredient, BLL.App.DTO.Ingredient>
    {
        public IngredientMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Ingredient MapToBll(IngredientAddPut ingredientAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Ingredient()
            {
                Id=ingredientAdd.Id,
                AppUserId = ingredientAdd.AppUserId,
                FoodItemId = ingredientAdd.FoodItemId,
                RecipeId = ingredientAdd.RecipeId,
                Quantity = ingredientAdd.Quantity
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}