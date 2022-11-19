using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class NutrientInSupplementMapper : BaseMapper<PublicApi.DTO.v1.NutrientInSupplement, BLL.App.DTO.NutrientInSupplement>
    {
        public NutrientInSupplementMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.NutrientInSupplement MapToBll(NutrientInSupplementAddPut nutrientInSupplementAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.NutrientInSupplement()
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