using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class ConsumedNutrientMapper : BaseMapper<PublicApi.DTO.v1.ConsumedNutrient, BLL.App.DTO.ConsumedNutrient>
    {
        public ConsumedNutrientMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.ConsumedNutrient MapToBll(ConsumedNutrientAddPut consumedNutrientAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.ConsumedNutrient()
            {
                Id = consumedNutrientAdd.Id,
                NutrientId = consumedNutrientAdd.NutrientId,
                AppUserId = consumedNutrientAdd.AppUserId,
                //N = consumedFoodItemAdd.FoodItem,
                Date = consumedNutrientAdd.Date,
                Quantity = consumedNutrientAdd.Quantity
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}