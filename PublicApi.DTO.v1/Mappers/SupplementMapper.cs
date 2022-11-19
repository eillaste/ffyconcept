using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class SupplementMapper : BaseMapper<PublicApi.DTO.v1.Supplement, BLL.App.DTO.Supplement>
    {
        public SupplementMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Supplement MapToBll(SupplementAddPut supplementAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Supplement()
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