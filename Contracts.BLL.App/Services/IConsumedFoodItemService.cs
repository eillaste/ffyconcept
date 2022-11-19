using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
//using Domain.App;
//using DTO.App;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IConsumedFoodItemService : IBaseEntityService<BLLAppDTO.ConsumedFoodItem, DALAppDTO.ConsumedFoodItem>, IConsumedFoodItemRepositoryCustom<BLLAppDTO.ConsumedFoodItem>
    {
        Task<IEnumerable<BLLAppDTO.ConsumedFoodItem>> GetAllFoodItemsWithInfo(Guid userId,
            bool noTracking = true);
    }
}