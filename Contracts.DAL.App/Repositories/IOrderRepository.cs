using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

//using Domain.App;

namespace Contracts.DAL.App.Repositories
{
    public interface IOrderRepository: IBaseRepository<Order>,IOrderRepositoryCustom<Order>
    {
        // add Entity custom method declarations here
        //Task DeleteAllByNameAsync(string name);
    }

    public interface IOrderRepositoryCustom<TEntity>
    {
        
    }
}