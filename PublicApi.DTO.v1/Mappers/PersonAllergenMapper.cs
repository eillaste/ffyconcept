using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class PersonAllergenMapper : BaseMapper<PublicApi.DTO.v1.PersonAllergen, BLL.App.DTO.PersonAllergen>
    {
        public PersonAllergenMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.PersonAllergen MapToBll(PersonAllergenAddPut personAllergenAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.PersonAllergen()
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