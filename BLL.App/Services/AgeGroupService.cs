using System;
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
    public class AgeGroupService : BaseEntityService<IAppUnitOfWork, IAgeGroupRepository, BLLAppDTO.AgeGroup, DALAppDTO.AgeGroup>, IAgeGroupService
    {
        public AgeGroupService(IAppUnitOfWork serviceUow, IAgeGroupRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new AgeGroupMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.AgeGroup>> GetAllWithRangeAsync(bool noTracking = true)
        {
            return (await ServiceRepository.GetAllWithRangeAsync(noTracking)).Select(x=>Mapper.Map(x))!;
        }

        public Task<BLLAppDTO.AgeGroup?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true)
        {
            throw new NotImplementedException();
        }
    }
}