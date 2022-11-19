using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class RecommendedDietaryIntakeMapper : BaseMapper<PublicApi.DTO.v1.RecommendedDietaryIntake, BLL.App.DTO.RecommendedDietaryIntake>
    {
        public RecommendedDietaryIntakeMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.RecommendedDietaryIntake MapToBll(RecommendedDietaryIntakeAddPut recommendedDietaryIntakeAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.RecommendedDietaryIntake()
            {
                Id = recommendedDietaryIntakeAdd.Id,
                NutrientId = recommendedDietaryIntakeAdd.NutrientId,
                AgeGroupId = recommendedDietaryIntakeAdd.AgeGroupId,
                Quantity = recommendedDietaryIntakeAdd.Quantity,
                Gender = recommendedDietaryIntakeAdd.Gender
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}