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
    public class RestaurantService: BaseEntityService<IAppUnitOfWork, IRestaurantRepository, BLLAppDTO.Restaurant, DALAppDTO.Restaurant>, IRestaurantService
    {
        public RestaurantService(IAppUnitOfWork serviceUow, IRestaurantRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new RestaurantMapper(mapper))
        {
        }
    }
}