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
    public class PersonRecommendedDietaryIntakeRepository: BaseRepository<DAL.App.DTO.PersonRecommendedDietaryIntake,Domain.App.PersonRecommendedDietaryIntake, AppDbContext>, IPersonRecommendedDietaryIntakeRepository
    {
        public PersonRecommendedDietaryIntakeRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new PersonRecommendedDietaryIntakeMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.PersonRecommendedDietaryIntake>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(p=>p.AppUser)
                .Include(p=>p.Nutrient)
                .Include(p => p.HealthSpecificationNutrient)
                .Include(p=>p.RecommendedDietaryIntake);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            if (userId != default)
            {
                query = query.Where(c => c.AppUserId == userId);
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.PersonRecommendedDietaryIntake?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            /*
            query = query
                .Include(p=>p.AppUser)
                .Include(p=>p.Nutrient)
                .Include(p => p.HealthSpecificationNutrient)
                .Include(p=>p.RecommendedDietaryIntake);
                */

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
    }
}