using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class AgeGroupMapper : BaseMapper<PublicApi.DTO.v1.AgeGroup, BLL.App.DTO.AgeGroup>
    {
        public AgeGroupMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.AgeGroup MapToBll(AgeGroupAddPut ageGroupAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.AgeGroup()
            {
                Id = ageGroupAdd.Id,
                LowerBound = ageGroupAdd.LowerBound,
                UpperBound = ageGroupAdd.UpperBound
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}