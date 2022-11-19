using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class MenuMapper : BaseMapper<PublicApi.DTO.v1.Menu, BLL.App.DTO.Menu>
    {
        public MenuMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Menu MapToBll(MenuAddPut menuAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Menu()
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