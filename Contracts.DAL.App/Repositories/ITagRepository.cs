using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface ITagRepository: IBaseRepository<Tag>, ITagRepositoryCustom<Tag>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface ITagRepositoryCustom<TEntity>
    {
        
    }
}