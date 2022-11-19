using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ConsumedNutrientService: BaseEntityService<IAppUnitOfWork, IConsumedNutrientRepository, BLLAppDTO.ConsumedNutrient, DALAppDTO.ConsumedNutrient>, IConsumedNutrientService
    {
        public ConsumedNutrientService(IAppUnitOfWork serviceUow, IConsumedNutrientRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new ConsumedNutrientMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.ConsumedNutrient>> GetAllWithNutrientDateAndQuantityAsync(Guid userId, bool noTracking = true)
        {
            return (await ServiceRepository.GetAllWithNutrientDateAndQuantityAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;
        }

        public async Task<BLLAppDTO.ConsumedNutrient?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var res = Mapper.Map(await ServiceRepository.FirstOrDefaultWithIncludesAsync(id, userId, noTracking));
            return res;
        }

        public async Task<IEnumerable<BLLAppDTO.ConsumedNutrient>> GetAllNutrientsWithInfo(Guid userId, bool noTracking = true)
        {
            //// not sure if this is correct
            var x = (await ServiceRepository.GetAllWithNutrientDateAndQuantityAsync(userId, noTracking)).Select(x =>
                Mapper.Map(x))!;
            /*Console.WriteLine("AAAAAAAAAAAA");
            Console.WriteLine(x.First()!.FoodItemName);*/
            return (await ServiceRepository.GetAllWithNutrientDateAndQuantityAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;
            //return res!;
        }
    }
}