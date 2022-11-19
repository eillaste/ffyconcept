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
    public class HealthSpecificationService: BaseEntityService<IAppUnitOfWork, IHealthSpecificationRepository, BLLAppDTO.HealthSpecification, DALAppDTO.HealthSpecification>, IHealthSpecificationService
    {
        public HealthSpecificationService(IAppUnitOfWork serviceUow, IHealthSpecificationRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new HealthSpecificationMapper(mapper))
        {
        }
    }
}