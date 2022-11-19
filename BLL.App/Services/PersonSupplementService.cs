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
    public class PersonSupplementService: BaseEntityService<IAppUnitOfWork, IPersonSupplementRepository, BLLAppDTO.PersonSupplement, DALAppDTO.PersonSupplement>, IPersonSupplementService
    {
        public PersonSupplementService(IAppUnitOfWork serviceUow, IPersonSupplementRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new PersonSupplementMapper(mapper))
        {
        }
    }
}