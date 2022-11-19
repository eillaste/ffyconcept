using System;
using System.Threading.Tasks;
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
    public class RecipeService: BaseEntityService<IAppUnitOfWork, IRecipeRepository, BLLAppDTO.Recipe, DALAppDTO.Recipe>, IRecipeService
    {
        public RecipeService(IAppUnitOfWork serviceUow, IRecipeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new RecipeMapper(mapper))
        {
        }

        public async Task<BLLAppDTO.Recipe?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true)
        {
            Console.WriteLine("AAPAPAPAPAPA");
            /*var abracadabra =
                ServiceRepository.FirstOrDefaultWithIncludesAsync(id, userId, noTracking).Result!.FoodItem!
                    .Title;
            Console.WriteLine(abracadabra);*/
            var res = Mapper.Map(await ServiceRepository.FirstOrDefaultWithIncludesAsync(id, userId, noTracking));
            return res;
        }
    }
}