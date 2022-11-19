using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class DishInMenuMapper : BaseMapper<PublicApi.DTO.v1.DishInMenu, BLL.App.DTO.DishInMenu>
    {
        public DishInMenuMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.DishInMenu MapToBll(DishInMenuAddPut dishInMenuAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.DishInMenu()
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