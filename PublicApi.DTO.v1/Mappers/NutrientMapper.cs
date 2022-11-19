using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class NutrientMapper : BaseMapper<PublicApi.DTO.v1.Nutrient, BLL.App.DTO.Nutrient>
    {
        public NutrientMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Nutrient MapToBll(NutrientAddPut nutrientAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Nutrient()
            {
                Id = nutrientAdd.Id,
                StandardUnitId = nutrientAdd.StandardUnitId,
                Title = nutrientAdd.Title
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}