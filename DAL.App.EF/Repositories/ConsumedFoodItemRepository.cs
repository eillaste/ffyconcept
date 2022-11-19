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
//using DTO.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ConsumedFoodItemRepository: BaseRepository<DAL.App.DTO.ConsumedFoodItem, Domain.App.ConsumedFoodItem, AppDbContext>, IConsumedFoodItemRepository
    {
        public ConsumedFoodItemRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new ConsumedFoodItemMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.ConsumedFoodItem>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(c => c.FoodItem)
                .Include(f => f.AppUser);


            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            if (userId != default)
            {
                query = query.Where(c => c.AppUserId == userId);
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            //Console.WriteLine(res.Count);
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.ConsumedFoodItem?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
        
        public async Task<DAL.App.DTO.ConsumedFoodItem?> FirstOrDefaultWithIncludesAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(c => c.FoodItem)
                .Include(f => f.AppUser);

            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
        

        public async Task<IEnumerable<DAL.App.DTO.ConsumedFoodItem>> GetAllWithFoodItemDateAndQuantityAsync(Guid userId, bool noTracking = true)
        {
            Console.WriteLine("WTF IS GOING ON");
            {
                var query = CreateQuery(userId, noTracking);
                var resQuery = query.Select(consumedFoodItem => new DAL.App.DTO.ConsumedFoodItem()
                    {
                        Id = consumedFoodItem.Id,
                        FoodItemId = consumedFoodItem.FoodItemId,
                        FoodItemName = consumedFoodItem.FoodItem!.Title,
                        Date = consumedFoodItem.Date,
                        Quantity = consumedFoodItem.Quantity
                    })
                    .OrderBy(x => x.Date);
                

                var res = await resQuery.ToListAsync();
                /*Console.WriteLine(res.Count);
                Console.WriteLine("HOW MANY?");
                Console.WriteLine(res[0].FoodItemName);
                Console.WriteLine("HOW MANY2?");*/
                return res;
            }
        }
    }
}