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
    public class RecipeTagService: BaseEntityService<IAppUnitOfWork, IRecipeTagRepository, BLLAppDTO.RecipeTag, DALAppDTO.RecipeTag>, IRecipeTagService
    {
        public RecipeTagService(IAppUnitOfWork serviceUow, IRecipeTagRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new RecipeTagMapper(mapper))
        {
        }
    }
}