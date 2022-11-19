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
    public class PersonSupplementRepository: BaseRepository<DAL.App.DTO.PersonSupplement,Domain.App.PersonSupplement, AppDbContext>, IPersonSupplementRepository
    {
        public PersonSupplementRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext, new PersonSupplementMapper(mapper))
        {
        }

        public override async Task<IEnumerable<DAL.App.DTO.PersonSupplement>> GetAllAsync(Guid userId, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query
                .Include(p=>p.AppUser)
                .Include(p => p.Supplement);
            if (userId != default)
            {
                query = query.Where(c => c.AppUserId == userId);
            }

            var res = await query.Select(x => Mapper.Map(x)).ToListAsync();
            return res!;
        }
        
        

        public override async Task<DAL.App.DTO.PersonSupplement?> FirstOrDefaultAsync(Guid id,Guid userId,  bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            query = query
                .Include(p=>p.AppUser)
                .Include(p => p.Supplement);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            var res = await query.FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
            return Mapper.Map(res);
        }
    }
}