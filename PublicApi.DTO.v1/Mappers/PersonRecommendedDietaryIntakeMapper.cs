using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class PersonRecommendedDietaryIntakeMapper : BaseMapper<PublicApi.DTO.v1.PersonRecommendedDietaryIntake, BLL.App.DTO.PersonRecommendedDietaryIntake>
    {
        public PersonRecommendedDietaryIntakeMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.PersonRecommendedDietaryIntake MapToBll(PersonRecommendedDietaryIntakeAddPut personRecommendedDietaryIntakeAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.PersonRecommendedDietaryIntake()
            {
                Id = personRecommendedDietaryIntakeAdd.Id,
                NutrientId = personRecommendedDietaryIntakeAdd.NutrientId,
                AppUserId = personRecommendedDietaryIntakeAdd.AppUserId,
                HealthSpecificationNutrientId = personRecommendedDietaryIntakeAdd.HealthSpecificationNutrientId,
                RecommendedDietaryIntakeId = personRecommendedDietaryIntakeAdd.RecommendedDietaryIntakeId,
                Start = personRecommendedDietaryIntakeAdd.Start,
                End = personRecommendedDietaryIntakeAdd.End
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}