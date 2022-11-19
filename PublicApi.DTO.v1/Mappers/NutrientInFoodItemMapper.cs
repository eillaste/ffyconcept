using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class NutrientInFoodItemMapper : BaseMapper<PublicApi.DTO.v1.NutrientInFoodItem, BLL.App.DTO.NutrientInFoodItem>
    {
        public NutrientInFoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.NutrientInFoodItem MapToBll(NutrientInFoodItemAddPut nutrientInFoodItemAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.NutrientInFoodItem()
            {
                Id = nutrientInFoodItemAdd.Id,
                NutrientId = nutrientInFoodItemAdd.NutrientId,
                FoodItemId = nutrientInFoodItemAdd.FoodItemId,
                Quantity = nutrientInFoodItemAdd.Quantity
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}