using System;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IRecipeService : IBaseEntityService<BLLAppDTO.Recipe,DALAppDTO.Recipe>, IRecipeRepositoryCustom<BLLAppDTO.Recipe>
    {
       // Task<bool> FirstOrDefaultWithIncludesAsync(Guid id, Guid appuserId, bool b);
    }
}