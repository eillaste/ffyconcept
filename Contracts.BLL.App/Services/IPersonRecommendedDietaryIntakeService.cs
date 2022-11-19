using System;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IPersonRecommendedDietaryIntakeService : IBaseEntityService<BLLAppDTO.PersonRecommendedDietaryIntake,DALAppDTO.PersonRecommendedDietaryIntake>, IPersonRecommendedDietaryIntakeRepositoryCustom<BLLAppDTO.PersonRecommendedDietaryIntake>
    {
        void RemoveAll(Guid userId, bool noTracking = true);
        Task<bool> RemoveOldRecommendationsAsync(Guid getUserId, bool b);
    }
}