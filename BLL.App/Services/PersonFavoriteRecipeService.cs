using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain.App;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class PersonFavoriteRecipeService: BaseEntityService<IAppUnitOfWork, IPersonFavoriteRecipeRepository, BLLAppDTO.PersonFavoriteRecipe, DALAppDTO.PersonFavoriteRecipe>, IPersonFavoriteRecipeService
    {
        public PersonFavoriteRecipeService(IAppUnitOfWork serviceUow, IPersonFavoriteRecipeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonFavoriteRecipeMapper(mapper))
        {
        }
    }
}