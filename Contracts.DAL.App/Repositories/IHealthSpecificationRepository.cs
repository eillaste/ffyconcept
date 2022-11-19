using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IHealthSpecificationRepository: IBaseRepository<HealthSpecification>, IHealthSpecificationRepositoryCustom<HealthSpecification>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IHealthSpecificationRepositoryCustom<TEntity>
    {
        
    }
}