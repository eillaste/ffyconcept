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
    public class TagService: BaseEntityService<IAppUnitOfWork, ITagRepository, BLLAppDTO.Tag, DALAppDTO.Tag>, ITagService
    {
        public TagService(IAppUnitOfWork serviceUow, ITagRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new TagMapper(mapper))
        {
        }
    }
}