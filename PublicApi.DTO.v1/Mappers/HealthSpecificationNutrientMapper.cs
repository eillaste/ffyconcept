using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class HealthSpecificationNutrientMapper : BaseMapper<PublicApi.DTO.v1.HealthSpecificationNutrient, BLL.App.DTO.HealthSpecificationNutrient>
    {
        public HealthSpecificationNutrientMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.HealthSpecificationNutrient MapToBll(HealthSpecificationNutrientAddPut healthSpecificationNutrientAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.HealthSpecificationNutrient()
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