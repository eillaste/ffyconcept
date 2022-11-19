using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class StateMapper : BaseMapper<PublicApi.DTO.v1.State, BLL.App.DTO.State>
    {
        public StateMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.State MapToBll(StateAddPut stateAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.State()
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