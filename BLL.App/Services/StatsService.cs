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
    public class StatsService: BaseEntityService<IAppUnitOfWork, IStateRepository, BLLAppDTO.State, DALAppDTO.State>, IStateService
    {
        public StatsService(IAppUnitOfWork serviceUow, IStateRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new StateMapper(mapper))
        {
        }
        
        public async Task<Dictionary<string, Dictionary<string, double>>> GetStatsAsync(Guid userId, DateTime dateTime, bool noTracking = true)
        {

            
            Dictionary<string, Dictionary<string, double>> statsDict =
                new Dictionary<string, Dictionary<string, double>>();

            var tolerableUpperIntakeLevels = await ServiceUow.TolerableUpperIntakeLevels.GetAllAsync();
            var personRecommendedUpperIntakeLevels = await ServiceUow.PersonRecommendedDietaryIntake.GetAllAsync(userId);
            //var standardUnits = await ServiceUow
            var consumedFoodItems = ServiceUow.ConsumedFoodItems.GetAllAsync(userId).Result.Where(r=>r.Date.Date == dateTime.Date);
            var consumedNutrients = ServiceUow.ConsumedNutrients.GetAllAsync(userId).Result
                .Where(r => r.Date.Date == dateTime.Date);
            
            Console.WriteLine("INSIDDE GET STATSASYNC");
            Console.WriteLine(userId);
            Console.WriteLine(dateTime);
            Console.WriteLine(tolerableUpperIntakeLevels.Count());
            Console.WriteLine(personRecommendedUpperIntakeLevels.Count());
            Console.WriteLine(consumedFoodItems.Count());
            Console.WriteLine(consumedNutrients.Count());
            /*return (await ServiceRepository.GetAllWithRangeAsync(noTracking)).Select(x=>Mapper.Map(x))!;*/
            Console.WriteLine("HUH???");
            return statsDict;
        }
    }
}