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
    public class HealthSpecificationNutrientService: BaseEntityService<IAppUnitOfWork, IHealthSpecificationNutrientRepository, BLLAppDTO.HealthSpecificationNutrient, DALAppDTO.HealthSpecificationNutrient>, IHealthSpecificationNutrientService
    {
        public HealthSpecificationNutrientService(IAppUnitOfWork serviceUow, IHealthSpecificationNutrientRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new HealthSpecificationNutrientMapper(mapper))
        {
        }
    }
}