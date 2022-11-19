using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class DishInOrderMapper : BaseMapper<PublicApi.DTO.v1.DishInOrder, BLL.App.DTO.DishInOrder>
    {
        public DishInOrderMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.DishInOrder MapToBll(DishInOrderAddPut dishInOrderAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.DishInOrder()
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