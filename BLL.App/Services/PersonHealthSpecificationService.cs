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
    public class PersonHealthSpecificationService: BaseEntityService<IAppUnitOfWork, IPersonHealthSpecificationRepository, BLLAppDTO.PersonHealthSpecification, DALAppDTO.PersonHealthSpecification>, IPersonHealthSpecificationService
    {
        public PersonHealthSpecificationService(IAppUnitOfWork serviceUow, IPersonHealthSpecificationRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository,new PersonHealthSpecificationMapper(mapper))
        {
        }
    }
}