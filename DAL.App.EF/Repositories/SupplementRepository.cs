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
    public class SupplementRepository: BaseRepository<DAL.App.DTO.Supplement,Domain.App.Supplement, AppDbContext>, ISupplementRepository
    {
        public SupplementRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new SupplementMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.Supplement>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            Console.WriteLine("AAAAAAAAAPPPPIIIIII");
            var query = CreateQuery(userId, noTracking);
        query = query
                .Include(s=>s.StandardUnit);
            
            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.Supplement?> FirstOrDefaultAsync(Guid id, Guid userId, bool noTracking = true)
        {
            
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(s=>s.StandardUnit);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }


            var res = await query.FirstOrDefaultAsync(m => m.Id == id);
            return Mapper.Map(res);
        }
    }
}