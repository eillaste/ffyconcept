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
    public class TolerableUpperIntakeLevelRepository: BaseRepository<DAL.App.DTO.TolerableUpperIntakeLevel,Domain.App.TolerableUpperIntakeLevel, AppDbContext>, ITolerableUpperIntakeLevelRepository
    {
        public TolerableUpperIntakeLevelRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new TolerableUpperIntakeLevelMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.TolerableUpperIntakeLevel>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(t=>t.Nutrient)
                .ThenInclude(n=>n!.StandardUnit);
           
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.TolerableUpperIntakeLevel?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            /*query = query
                .Include(t=>t.Nutrient)
                .ThenInclude(n=>n!.StandardUnit);*/

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}