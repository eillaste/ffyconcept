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
    public class IngredientService: BaseEntityService<IAppUnitOfWork, IIngredientRepository, BLLAppDTO.Ingredient, DALAppDTO.Ingredient>, IIngredientService
    {
        public IngredientService(IAppUnitOfWork serviceUow, IIngredientRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new IngredientMapper(mapper))
        {
        }
    }
}