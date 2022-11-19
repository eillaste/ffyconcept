using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class PersonDietMapper : BaseMapper<PublicApi.DTO.v1.PersonDiet, BLL.App.DTO.PersonDiet>
    {
        public PersonDietMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.PersonDiet MapToBll(PersonDietAddPut personDietAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.PersonDiet()
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