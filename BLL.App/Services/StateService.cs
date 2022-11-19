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
    public class StateService: BaseEntityService<IAppUnitOfWork, IStateRepository, BLLAppDTO.State, DALAppDTO.State>, IStateService
    {
        public StateService(IAppUnitOfWork serviceUow, IStateRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new StateMapper(mapper))
        {
        }
        
        public async Task<Dictionary<string, Dictionary<string, double>>> GetStatsAsync(Guid userId, DateTime dateTime, bool noTracking = true)
        {
            Console.WriteLine("INSIDDE GET STATSASYNC");
            Console.WriteLine(userId);
            Console.WriteLine(dateTime);
            Dictionary<string, Dictionary<string, double>> statsDict =
                new Dictionary<string, Dictionary<string, double>>();

            var tolerableUpperIntakeLevels = await ServiceUow.TolerableUpperIntakeLevels.GetAllAsync();
            var personRecommendedDietaryIntakes = await ServiceUow.PersonRecommendedDietaryIntake.GetAllAsync(userId);
            //var standardUnits = await ServiceUow
            var consumedFoodItems = ServiceUow.ConsumedFoodItems.GetAllAsync(userId).Result.Where(r=>r.Date.Date == dateTime.Date);
            var consumedNutrients = ServiceUow.ConsumedNutrients.GetAllAsync(userId).Result
                .Where(r => r.Date.Date == dateTime.Date);
            
            Console.WriteLine(tolerableUpperIntakeLevels.Count());
            Console.WriteLine(personRecommendedDietaryIntakes.Count());
            Console.WriteLine(consumedFoodItems.Count());
            Console.WriteLine(consumedNutrients.Count());
            /*return (await ServiceRepository.GetAllWithRangeAsync(noTracking)).Select(x=>Mapper.Map(x))!;*/

            
            statsDict["tolerableUpperIntakeLevels"] = new Dictionary<string, double>();
            statsDict["personRecommendedUpperIntakeLevels"] = new Dictionary<string, double>();
            statsDict["consumedFoodItems"] = new Dictionary<string, double>();
            statsDict["consumedNutrients"] = new Dictionary<string, double>();
            
            foreach (var tolerableUpperIntakeLevel in tolerableUpperIntakeLevels)
            {
                Console.WriteLine(tolerableUpperIntakeLevel.Nutrient!.Title);
                if (statsDict["tolerableUpperIntakeLevels"].ContainsKey(tolerableUpperIntakeLevel.Nutrient!.Title!))
                {
                    statsDict["tolerableUpperIntakeLevels"][tolerableUpperIntakeLevel.Nutrient!.Title!] =
                        statsDict["tolerableUpperIntakeLevels"][tolerableUpperIntakeLevel.Nutrient!.Title!] +
                        tolerableUpperIntakeLevel.Quantity;
                }
                else
                {
                    statsDict["tolerableUpperIntakeLevels"][tolerableUpperIntakeLevel.Nutrient!.Title!] = tolerableUpperIntakeLevel.Quantity;
                }
            }
            
            foreach (var personRecommendedDietaryIntake in personRecommendedDietaryIntakes)
            {
                Console.WriteLine(personRecommendedDietaryIntake.Nutrient!.Title);
                Console.WriteLine(personRecommendedDietaryIntake.RecommendedDietaryIntake!.Quantity);
                if (statsDict["personRecommendedUpperIntakeLevels"].ContainsKey(personRecommendedDietaryIntake.Nutrient!.Title!))
                {
                    statsDict["personRecommendedUpperIntakeLevels"][personRecommendedDietaryIntake.Nutrient!.Title!] =
                        statsDict["personRecommendedUpperIntakeLevels"][personRecommendedDietaryIntake.Nutrient!.Title!] +
                        personRecommendedDietaryIntake.RecommendedDietaryIntake.Quantity;
                }
                else
                {
                    statsDict["personRecommendedUpperIntakeLevels"][personRecommendedDietaryIntake.Nutrient!.Title!] = personRecommendedDietaryIntake.RecommendedDietaryIntake.Quantity;
                }
            }
            
            foreach (var consumedFoodItem in consumedFoodItems)
            {
                /*Console.WriteLine(consumedFoodItem.FoodItem!.Title);
                Console.WriteLine(consumedFoodItem.Quantity);*/
                if (statsDict.ContainsKey("consumedFoodItems"))
                    if (statsDict["consumedFoodItems"].ContainsKey(consumedFoodItem!.FoodItem!.Title!))
                    {
                        statsDict["consumedFoodItems"][consumedFoodItem.FoodItem!.Title!] =
                            statsDict["consumedFoodItems"][consumedFoodItem.FoodItem!.Title!] +
                            consumedFoodItem.Quantity;
                    }
                    else
                    {
                        statsDict["consumedFoodItems"][consumedFoodItem.FoodItem!.Title!] =
                            consumedFoodItem.Quantity;
                    }
            }
            
            foreach (var consumedNutrient in consumedNutrients)
            {
                /*Console.WriteLine(consumedNutrient.Nutrient!.Title);
                Console.WriteLine(consumedNutrient.Quantity);*/
                if (statsDict["consumedNutrients"].ContainsKey(consumedNutrient.Nutrient!.Title!))
                {
                    statsDict["consumedNutrients"][consumedNutrient.Nutrient!.Title!] = 
                        statsDict["consumedNutrients"][consumedNutrient.Nutrient!.Title!]+
                        consumedNutrient.Quantity;
                }
                else
                {
                    statsDict["consumedNutrients"][consumedNutrient.Nutrient!.Title!] = consumedNutrient.Quantity;
                }
            }


            Console.WriteLine("Meal registered");
            Console.WriteLine(statsDict.Count);
            /*statsDict["tolerableUpperIntakeLevels"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            statsDict["personRecommendedUpperIntakeLevels"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            statsDict["consumedFoodItems"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            statsDict["consumedNutrients"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");*/
            Console.WriteLine("HUH???");
            await ServiceUow.SaveChangesAsync();
            return statsDict;
        }
    }
}