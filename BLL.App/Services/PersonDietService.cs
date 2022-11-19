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
    public class PersonDietService: BaseEntityService<IAppUnitOfWork, IPersonDietRepository, BLLAppDTO.PersonDiet, DALAppDTO.PersonDiet>, IPersonDietService
    {
        public PersonDietService(IAppUnitOfWork serviceUow, IPersonDietRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonDietMapper(mapper))
        {
        }
    }
}