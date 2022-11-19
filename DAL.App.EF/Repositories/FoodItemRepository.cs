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
    public class FoodItemRepository: BaseRepository<DAL.App.DTO.FoodItem,Domain.App.FoodItem, AppDbContext>, IFoodItemRepository
    {
        public FoodItemRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new FoodItemMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.FoodItem>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            //Console.WriteLine("CUNT");
            var query = CreateQuery(userId, noTracking);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(f => f.Category)
                .Include(f => f.StandardUnit);
            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.FoodItem?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();
            query = query
                .Include(f => f.Category)
                .Include(f => f.StandardUnit);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }

        public async Task<IEnumerable<DAL.App.DTO.FoodItem>> GetAllWithCountsAsync(bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);
            query = query
                .Include(f => f.Category)
                .Include(f => f.StandardUnit);
            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            /*var resQuery = query.Select(foodItem => new FoodItemDTO()
            {
                Id = foodItem.Id,
                Title = foodItem.Title,
                StandardUnitId = foodItem.StandardUnitId,
                StandardUnit = foodItem.StandardUnit!.Title,
                CategoryId = foodItem.CategoryId,
                Category = foodItem.Category!.Title,
                PersonAllergens = foodItem.PersonAllergens!.Count,
                Ingredients = foodItem.Ingredients!.Count,
                Stocks = foodItem.Stocks!.Count,
                DietaryRestrictions = foodItem.DietaryRestrictions!.Count,
                NutrientInFoodItems = foodItem.NutrientInFoodItems!.Count,
                ConsumedFoodItems = foodItem.ConsumedFoodItems!.Count,
            })
                .OrderBy(x=>x.Title)
                .ThenBy(x=>x.Category);*/
            /*var res = await resQuery.ToListAsync();
            return res;*/
            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
    }
}