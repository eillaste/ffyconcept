using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonDietRepository: IBaseRepository<PersonDiet>,IPersonDietRepositoryCustom<PersonDiet>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IPersonDietRepositoryCustom<TEntity>
    {
        
    }
}