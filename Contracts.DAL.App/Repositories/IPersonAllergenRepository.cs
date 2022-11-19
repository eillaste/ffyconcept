using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonAllergenRepository: IBaseRepository<PersonAllergen>,IPersonAllergenRepositoryCustom<PersonAllergen>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IPersonAllergenRepositoryCustom<TEntity>
    {
        
    }
}