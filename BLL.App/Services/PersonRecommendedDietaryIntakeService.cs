using System;
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
    public class PersonRecommendedDietaryIntakeService: BaseEntityService<IAppUnitOfWork, IPersonRecommendedDietaryIntakeRepository, BLLAppDTO.PersonRecommendedDietaryIntake, DALAppDTO.PersonRecommendedDietaryIntake>, IPersonRecommendedDietaryIntakeService
    {
        public PersonRecommendedDietaryIntakeService(IAppUnitOfWork serviceUow, IPersonRecommendedDietaryIntakeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonRecommendedDietaryIntakeMapper(mapper))
        {
        }
        
        public void RemoveAll(Guid userId, bool noTracking = true)
        {
            Console.WriteLine("Inside Remove ALL in PRDIS");
            var res = ServiceRepository.GetAllAsync().Result.Where(r=>r.AppUserId == userId);
            Console.WriteLine(res.Count());
            foreach (var r in res)
            {
                Console.WriteLine("Iteration in PRDIS");
                var a = ServiceRepository.Remove(r, userId);
                Console.WriteLine("Fails here");
            }
        }
        
        public async Task<bool> RemoveOldRecommendationsAsync(Guid userId, bool noTracking = true)
        {
            /*return (await ServiceRepository.GetAllWithFoodItemDateAndQuantityAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;*/
            Console.WriteLine("Inside Remove ALL in PRDIS");
            var res = ServiceUow.PersonRecommendedDietaryIntake.GetAllAsync().Result.Where(r=>r.AppUserId == userId);
            //await ServiceUow.SaveChangesAsync();
            Console.WriteLine(res.Count());
            foreach (var r in res)
            {
                Console.WriteLine("Iteration in PRDIS");
                //var a = ServiceRepository.Remove(r, userId);
                await ServiceUow.PersonRecommendedDietaryIntake.RemoveAsync(r.Id, userId);
                //await ServiceUow.SaveChangesAsync();
                Console.WriteLine("Fails here");
            }

            await ServiceUow.SaveChangesAsync();
            return true;
        }
    }
}