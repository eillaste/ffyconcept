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
    public class StockService: BaseEntityService<IAppUnitOfWork, IStockRepository, BLLAppDTO.Stock, DALAppDTO.Stock>, IStockService
    {
        public StockService(IAppUnitOfWork serviceUow, IStockRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new StockMapper(mapper))
        {
        }
    }
}