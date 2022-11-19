using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class OrderMapper : BaseMapper<PublicApi.DTO.v1.Order, BLL.App.DTO.Order>
    {
        public OrderMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Order MapToBll(OrderAddPut orderAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Order()
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