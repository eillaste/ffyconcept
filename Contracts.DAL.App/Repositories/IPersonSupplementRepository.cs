using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonSupplementRepository: IBaseRepository<PersonSupplement>,IPersonSupplementRepositoryCustom<PersonSupplement>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name, Guid userId);
    }

    public interface IPersonSupplementRepositoryCustom<TEntity>
    {
        
    }
}