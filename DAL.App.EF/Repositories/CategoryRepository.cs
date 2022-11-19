using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories

{
    public class CategoryRepository : BaseRepository<DAL.App.DTO.Category, Domain.App.Category, AppDbContext>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new CategoryMapper(mapper))
        {
        }
        
        public override async Task<IEnumerable<DAL.App.DTO.Category>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var resQuery = CreateQuery(userId, noTracking)
                .Select(x=>Mapper.Map(x));

            if (noTracking)
            {
                resQuery = resQuery.AsNoTracking();
            }
            //query = query.Include(c => c.FoodItems??????)
            var res = await resQuery.ToListAsync();
            return res!;
        }
        
        public override async Task<DAL.App.DTO.Category?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            //query=

            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}