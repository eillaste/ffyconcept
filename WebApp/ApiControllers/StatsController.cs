using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App.Mappers;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.EF;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize(Roles="customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    public class StatsController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        //private ConsumedFoodItemMapper _consumedFoodItemMapper;
        private PersonRecommendedDietaryIntakeMapper _personRecommendedDietaryIntakeMapper;

        public StatsController(AppDbContext context,IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _bll = bll;
            _uow = uow;
            // Mapper = mapper;
            //_consumedFoodItemMapper = new ConsumedFoodItemMapper(Mapper);
            Mapper = mapper;
            _personRecommendedDietaryIntakeMapper = new PersonRecommendedDietaryIntakeMapper(Mapper);
        }
        

        
        
        /* example data
         {
            "id": "6D0EB75A-27EA-44A1-D0A1-08D916CD5901",
            "time": "2021-05-22T13:19:00"
        }
        */
        
        // POST: api/Stats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one Stats, Based on parameters:
        /// </summary>
        /// <param name="data">Id of object to retrieve, Guid</param>
        /// <returns></returns>
        [HttpPost("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Dictionary<string, Dictionary<string, double>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Dictionary<string, Dictionary<string, double>>> Index(Stats data)
        {
            Console.WriteLine(data.Id);
            Console.WriteLine(data.Time);
            /*if (data.Id != User!.GetUserId()!.Value!)
            {
                return new Dictionary<string, Dictionary<string, double>>();
            }*/
            
            var stats = await _bll.State.GetStatsAsync(data.Id, data.Time, true);
            
            Console.WriteLine("INSIDE APICONTROLLER RESULT");
            stats["tolerableUpperIntakeLevels"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            stats["personRecommendedUpperIntakeLevels"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            stats["consumedFoodItems"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            stats["consumedNutrients"].Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            return stats;

        }
    }
}