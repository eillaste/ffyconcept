using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class StandardUnitMapper : BaseMapper<PublicApi.DTO.v1.StandardUnit, BLL.App.DTO.StandardUnit>
    {
        public StandardUnitMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.StandardUnit MapToBll(StandardUnitAddPut standardUnitAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.StandardUnit()
            {
                Id = standardUnitAdd.Id,
                Title = standardUnitAdd.Title,
                Symbol = standardUnitAdd.Symbol
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}