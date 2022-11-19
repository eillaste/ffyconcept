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
    public class DishInOrderService: BaseEntityService<IAppUnitOfWork, IDishInOrderRepository, BLLAppDTO.DishInOrder, DALAppDTO.DishInOrder>, IDishInOrderService
    {
        public DishInOrderService(IAppUnitOfWork serviceUow, IDishInOrderRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new DishInOrderMapper(mapper))
        {
        }
    }
}