using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using Contracts.Domain.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class OrderRepository: BaseRepository<DAL.App.DTO.Order,Domain.App.Order, AppDbContext>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new OrderMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Order>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }

        //    query = query
        //        .Include(o => o.State)
         //       .Include(o => o.Person)
         //       .Include(o => o.Invoice)
         //       .Include(o => o.OrderedDishes);
         var res = await resQuery.ToListAsync();
         return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Order?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }

         //   query = query
         //       .Include(o => o.State)
         //       .Include(o => o.Person)
         //       .Include(o => o.Invoice)
         //       .Include(o => o.OrderedDishes);

         var res = Mapper.Map(await query.FirstOrDefaultAsync(m => m.Id == id));
         return res;
        }
    }
}