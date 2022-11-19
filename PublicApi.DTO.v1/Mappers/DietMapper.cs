using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class DietMapper : BaseMapper<PublicApi.DTO.v1.Diet, BLL.App.DTO.Diet>
    {
        public DietMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Diet MapToBll(DietAddPut dietAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Diet()
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