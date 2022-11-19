using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class TagMapper : BaseMapper<PublicApi.DTO.v1.Tag, BLL.App.DTO.Tag>
    {
        public TagMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Tag MapToBll(TagAddPut tagAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Tag()
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