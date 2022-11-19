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
    public class FoodItemService: BaseEntityService<IAppUnitOfWork, IFoodItemRepository, BLLAppDTO.FoodItem, DALAppDTO.FoodItem>, IFoodItemService
    {
        public FoodItemService(IAppUnitOfWork serviceUow, IFoodItemRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new FoodItemMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.FoodItem>> GetAllWithCountsAsync(bool noTracking = true)
        {
            return (await ServiceRepository.GetAllWithCountsAsync(noTracking)).Select(x=>Mapper.Map(x))!;
        }
    }
}