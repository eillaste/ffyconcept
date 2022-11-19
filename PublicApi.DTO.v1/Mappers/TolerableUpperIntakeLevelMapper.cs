using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class TolerableUpperIntakeLevelMapper : BaseMapper<PublicApi.DTO.v1.TolerableUpperIntakeLevel, BLL.App.DTO.TolerableUpperIntakeLevel>
    {
        public TolerableUpperIntakeLevelMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.TolerableUpperIntakeLevel MapToBll(TolerableUpperIntakeLevelAddPut tolerableUpperIntakeLevelAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.TolerableUpperIntakeLevel()
            {
                Id = tolerableUpperIntakeLevelAdd.Id,
                NutrientId = tolerableUpperIntakeLevelAdd.NutrientId,
                Quantity = tolerableUpperIntakeLevelAdd.Quantity
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}