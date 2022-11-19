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
    public class SupplementService: BaseEntityService<IAppUnitOfWork, ISupplementRepository,BLLAppDTO.Supplement, DALAppDTO.Supplement>, ISupplementService
    {
        public SupplementService(IAppUnitOfWork serviceUow, ISupplementRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new SupplementMapper(mapper))
        {
        }
    }
}