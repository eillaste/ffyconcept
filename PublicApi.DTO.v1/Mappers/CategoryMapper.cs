using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class CategoryMapper : BaseMapper<PublicApi.DTO.v1.Category, BLL.App.DTO.Category>
    {
        public CategoryMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.Category MapToBll(CategoryAddPut categoryAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.Category()
            {
                Id = categoryAdd.Id,
                Title = categoryAdd.Title
            };

            /*
            res.Contacts = 
                personAdd.Contacts.Select(x => ContactMapper.MapToBll(x)).ToList();
            */
            return res;
        }

    }
}