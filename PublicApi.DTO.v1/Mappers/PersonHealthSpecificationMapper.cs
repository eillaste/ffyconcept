using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class PersonHealthSpecificationMapper : BaseMapper<PublicApi.DTO.v1.PersonHealthSpecification, BLL.App.DTO.PersonHealthSpecification>
    {
        public PersonHealthSpecificationMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.PersonHealthSpecification MapToBll(PersonHealthSpecificationAddPut personHealthSpecificationAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.PersonHealthSpecification()
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