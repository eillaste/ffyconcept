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
    public class NutrientInSupplementService: BaseEntityService<IAppUnitOfWork, INutrientInSupplementRepository, BLLAppDTO.NutrientInSupplement, DALAppDTO.NutrientInSupplement>, INutrientInSupplementService
    {
        public NutrientInSupplementService(IAppUnitOfWork serviceUow, INutrientInSupplementRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new NutrientInSupplementMapper(mapper))
        {
        }
    }
}