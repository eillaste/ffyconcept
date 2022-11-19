using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PublicApi.DTO.v1.Mappers;
//using EGender = PublicApi.DTO.v1.EGender

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecommendedDietaryIntakeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private RecommendedDietaryIntakeMapper _recommendedDietaryIntakeMapper;

        public RecommendedDietaryIntakeController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _recommendedDietaryIntakeMapper = new RecommendedDietaryIntakeMapper(Mapper);
        }

        // GET: api/RecommendedDietaryIntake
        /// <summary>
        /// Get all RecommendedDietaryIntake
        /// </summary>
        /// <returns>List of RecommendedDietaryIntake</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.RecommendedDietaryIntake>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.RecommendedDietaryIntake>>> GetRecommendedDietaryIntake()
        {
            return Ok((await _bll.RecommendedDietaryIntake.GetAllAsync()).Select(s => 
                Mapper.Map<BLL.App.DTO.RecommendedDietaryIntake, PublicApi.DTO.v1.RecommendedDietaryIntake>(s)
));
        }

        // GET: api/RecommendedDietaryIntake/5
        /// <summary>
        /// Get one RecommendedDietaryIntake, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>RecommendedDietaryIntake entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.RecommendedDietaryIntake), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.RecommendedDietaryIntake>> GetRecommendedDietaryIntake(Guid id)
        {
            var recommendedDietaryIntake = await _bll.RecommendedDietaryIntake.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (recommendedDietaryIntake == null)
            {
                return NotFound();
            }
            
            /*var res = new PublicApi.DTO.v1.RecommendedDietaryIntake()
            {
                Id = recommendedDietaryIntake.Id,
                NutrientId = recommendedDietaryIntake.NutrientId,
                AgeGroupId = recommendedDietaryIntake.AgeGroupId,
                Quantity = recommendedDietaryIntake.Quantity,
                Gender = recommendedDietaryIntake.Gender
            };*/
            return Mapper.Map<BLL.App.DTO.RecommendedDietaryIntake, PublicApi.DTO.v1.RecommendedDietaryIntake>(recommendedDietaryIntake);
        }

        // PUT: api/RecommendedDietaryIntake/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one RecommendedDietaryIntake, Based on parameters: Id, RecommendedDietaryIntake
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recommendedDietaryIntake"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.RecommendedDietaryIntake), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutRecommendedDietaryIntake(Guid id, PublicApi.DTO.v1.RecommendedDietaryIntakeAddPut recommendedDietaryIntake)
        {
            if (id != recommendedDietaryIntake.Id)
            {
                return BadRequest();
            }

            var bllRecommendedDietaryIntake = RecommendedDietaryIntakeMapper.MapToBll(recommendedDietaryIntake);
            _bll.RecommendedDietaryIntake.Update(bllRecommendedDietaryIntake);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/RecommendedDietaryIntake
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add RecommendedDietaryIntake, Based on request body: RecommendedDietaryIntake
        /// </summary>
        /// <param name="recommendedDietaryIntake"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.RecommendedDietaryIntake), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.RecommendedDietaryIntake>> PostRecommendedDietaryIntake(PublicApi.DTO.v1.RecommendedDietaryIntakeAddPut recommendedDietaryIntake)
        {
            var bllRecommendedDietaryIntake = RecommendedDietaryIntakeMapper.MapToBll(recommendedDietaryIntake);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedRecommendedDietaryIntake = _bll.RecommendedDietaryIntake.Add(bllRecommendedDietaryIntake);
            await _bll.SaveChangesAsync();
            var returnRecommendedDietaryIntake = _recommendedDietaryIntakeMapper.Map(addedRecommendedDietaryIntake);
            
            // this is sketchy af
            //returnAgeGroup!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetRecommendedDietaryIntake", new {id = returnRecommendedDietaryIntake!.Id}, returnRecommendedDietaryIntake);
        }

        // DELETE: api/RecommendedDietaryIntake/5
        /// <summary>
        /// Delete RecommendedDietaryIntake, Based on parameter: id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteRecommendedDietaryIntake(Guid id)
        {
            var recommendedDietaryIntake = await _bll.RecommendedDietaryIntake.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (recommendedDietaryIntake == null)
            {
                return NotFound();
            }

            _bll.RecommendedDietaryIntake.Remove(recommendedDietaryIntake);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool>  RecommendedDietaryIntakeExists(Guid id)
        {
            return await _bll.RecommendedDietaryIntake.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
