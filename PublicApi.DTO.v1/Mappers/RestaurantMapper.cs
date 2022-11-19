using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class RestaurantMapper : BaseMapper<PublicApi.DTO.v1.Restaurant, BLL.App.DTO.Restaurant>
    {
        public RestaurantMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Restaurant MapToBll(RestaurantAddPut restaurantAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Restaurant()
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