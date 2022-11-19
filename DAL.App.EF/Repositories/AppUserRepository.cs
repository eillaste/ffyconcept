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
    public class AppUserRepository: BaseRepository<DAL.App.DTO.Identity.AppUser, Domain.App.Identity.AppUser, AppDbContext>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new AppUserMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Identity.AppUser>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            /*
            query = query
                .Include(c => c.ConsumedNutrients)
                .Include(f => f.ConsumedFoodItems)
                .Include(g => g.PersonRecommendedDietaryIntakes);
                */


            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            if (userId != default)
            {
                query = query.Where(c => c.Id == userId);
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();

            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Identity.AppUser?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.Id == userId);
            return Mapper.Map(res);
        }
        
        public async Task<DAL.App.DTO.Identity.AppUser?> FirstOrDefaultWithIncludesAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            
            var query = CreateQuery(userId, noTracking);

            query = query
                .Include(c => c.ConsumedNutrients)
                .Include(f => f.ConsumedFoodItems)
                .Include(g => g.PersonRecommendedDietaryIntakes);

            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.Id == userId);
            return Mapper.Map(res);
        }
        

        public async Task<IEnumerable<DAL.App.DTO.Identity.AppUser>> GetAllWithFoodItemDateAndQuantityAsync(Guid userId, bool noTracking = true)
        {
        //this is not right
            {
                var query = CreateQuery(userId, noTracking);
                var resQuery = query.Select(appUser => new DAL.App.DTO.Identity.AppUser()
                    {
                        Id = appUser.Id,

                    })
                    .OrderBy(x => x.Id);
                

                var res = await resQuery.ToListAsync();

                return res;
            }
        }
    }
}