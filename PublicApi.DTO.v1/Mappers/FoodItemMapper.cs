using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class FoodItemMapper : BaseMapper<PublicApi.DTO.v1.FoodItem, BLL.App.DTO.FoodItem>
    {
        public FoodItemMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.FoodItem MapToBll(FoodItemAddPut foodItemAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.FoodItem()
            {
                Id = foodItemAdd.Id,
                Title = foodItemAdd.Title,
                StandardUnitId = foodItemAdd.StandardUnitId,
                CategoryId = foodItemAdd.CategoryId
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}