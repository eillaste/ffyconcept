using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class PersonSupplementMapper : BaseMapper<PublicApi.DTO.v1.PersonSupplement, BLL.App.DTO.PersonSupplement>
    {
        public PersonSupplementMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.PersonSupplement MapToBll(PersonSupplementAddPut personSupplementAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.PersonSupplement()
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