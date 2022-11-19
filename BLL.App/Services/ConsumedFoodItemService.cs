﻿using System;
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
//using DTO.App;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class ConsumedFoodItemService: BaseEntityService<IAppUnitOfWork, IConsumedFoodItemRepository, BLLAppDTO.ConsumedFoodItem, DALAppDTO.ConsumedFoodItem>, IConsumedFoodItemService
    {
        public ConsumedFoodItemService(IAppUnitOfWork serviceUow, IConsumedFoodItemRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new ConsumedFoodItemMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.ConsumedFoodItem>> GetAllWithFoodItemDateAndQuantityAsync(Guid userId, bool noTracking = true)
        {
            return (await ServiceRepository.GetAllWithFoodItemDateAndQuantityAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;
        }

        public async Task<BLLAppDTO.ConsumedFoodItem?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true)
        {
            Console.WriteLine("AAPAPAPAPAPA");
            /*var abracadabra =
                ServiceRepository.FirstOrDefaultWithIncludesAsync(id, userId, noTracking).Result!.FoodItem!
                    .Title;
            Console.WriteLine(abracadabra);*/
            var res = Mapper.Map(await ServiceRepository.FirstOrDefaultWithIncludesAsync(id, userId, noTracking));
            return res;
        }

        public async Task<IEnumerable<BLLAppDTO.ConsumedFoodItem>> GetAllFoodItemsWithInfo(Guid userId, bool noTracking = true)
        {
            //// not sure if this is correct
            var x = (await ServiceRepository.GetAllWithFoodItemDateAndQuantityAsync(userId, noTracking)).Select(x =>
                Mapper.Map(x))!;
            /*Console.WriteLine("AAAAAAAAAAAA");
            Console.WriteLine(x.First()!.FoodItemName);*/
            return (await ServiceRepository.GetAllWithFoodItemDateAndQuantityAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;
            //return res!;
        }
    }
}