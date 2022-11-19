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
    public class RecipeRepository: BaseRepository<DAL.App.DTO.Recipe,Domain.App.Recipe, AppDbContext>, IRecipeRepository
    {
        public RecipeRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new RecipeMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Recipe>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }

            //query = query
            //    .Include(r=>r.FoodItems)
            //    .Include(r=>r.Tags)
            //    .Include(r=>r.Menus);
            var res = await resQuery.ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Recipe?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateSpecialQuery(userId, noTracking);

            //var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

          //  query = query
          //      .Include(r=>r.FoodItems)
          //      .Include(r=>r.Tags)
           //     .Include(r=>r.Menus);
            
            
           var res = await query.FirstOrDefaultAsync(m => m.Id == id);
           return Mapper.Map(res);
        }
        
        public async Task<DAL.App.DTO.Recipe?> FirstOrDefaultWithIncludesAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateSpecialQuery(userId, noTracking);

            //var resQuery = query.Select(x => Mapper.Map(x));

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.FoodItem)
                .ThenInclude(fi=>fi!.StandardUnit)
                .Include(r=>r.Ingredients)
                .ThenInclude(i=>i.FoodItem)
                .ThenInclude(f => f!.NutrientInFoodItems)
                .ThenInclude(nif => nif.Nutrient)
                .ThenInclude(n=>n!.StandardUnit);

            Console.WriteLine("insiderecipefirstwithincludes");
            
            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}