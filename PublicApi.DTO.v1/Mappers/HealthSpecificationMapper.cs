using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class HealthSpecificationMapper : BaseMapper<PublicApi.DTO.v1.HealthSpecification, BLL.App.DTO.HealthSpecification>
    {
        public HealthSpecificationMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.HealthSpecification MapToBll(HealthSpecificationAddPut healthSpecificationAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.HealthSpecification()
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