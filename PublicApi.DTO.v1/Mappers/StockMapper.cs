using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class StockMapper : BaseMapper<PublicApi.DTO.v1.Stock, BLL.App.DTO.Stock>
    {
        public StockMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Stock MapToBll(StockAddPut stockAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Stock()
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