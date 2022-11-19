using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class DietaryRestrictionMapper : BaseMapper<PublicApi.DTO.v1.DietaryRestriction, BLL.App.DTO.DietaryRestriction>
    {
        public DietaryRestrictionMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.DietaryRestriction MapToBll(DietaryRestrictionAddPut dietaryRestrictionAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.DietaryRestriction()
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