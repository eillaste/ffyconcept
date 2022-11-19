using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class PersonFavoriteRecipeMapper : BaseMapper<PublicApi.DTO.v1.PersonFavoriteRecipe, BLL.App.DTO.PersonFavoriteRecipe>
    {
        public PersonFavoriteRecipeMapper(IMapper mapper) : base(mapper)
        {
        }
        
        public static BLL.App.DTO.PersonFavoriteRecipe MapToBll(PersonFavoriteRecipeAddPut personFavoriteRecipeAdd)
        {
            // maybe we need custom logic here
            // return Mapper.Map<BLL.App.DTO.Person>(personAdd);
            var res = new BLL.App.DTO.PersonFavoriteRecipe()
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