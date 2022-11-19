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
    public interface IAppUserService : IBaseEntityService<BLLAppDTO.Identity.AppUser, DALAppDTO.Identity.AppUser>, IAppUserRepositoryCustom<BLLAppDTO.Identity.AppUser>
    {
        Task<IEnumerable<BLLAppDTO.Identity.AppUser>> GetAllFoodItemsWithInfo(Guid userId,
            bool noTracking = true);
    }
}