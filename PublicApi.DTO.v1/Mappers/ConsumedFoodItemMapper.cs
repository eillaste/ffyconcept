using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class ConsumedFoodItemMapper : BaseMapper<PublicApi.DTO.v1.ConsumedFoodItem, BLL.App.DTO.ConsumedFoodItem>
    {
        public ConsumedFoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.ConsumedFoodItem MapToBll(ConsumedFoodItemAddPut consumedFoodItemAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.ConsumedFoodItem()
            {
                Id = consumedFoodItemAdd.Id,
                FoodItemId = consumedFoodItemAdd.FoodItemId,
                AppUserId = consumedFoodItemAdd.AppUserId,
                FoodItemName = consumedFoodItemAdd.FoodItem,
                Date = consumedFoodItemAdd.Date,
                Quantity = consumedFoodItemAdd.Quantity
            };

            return res;
        }

    }
}