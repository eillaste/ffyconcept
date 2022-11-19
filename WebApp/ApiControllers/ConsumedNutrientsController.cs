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

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ConsumedNutrientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private ConsumedNutrientMapper _consumedNutrientMapper;

        public ConsumedNutrientsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _consumedNutrientMapper = new ConsumedNutrientMapper(Mapper);
        }

        // GET: api/ConsumedNutrients
        /// <summary>
        /// Get all ConsumedNutrients
        /// </summary>
        /// <returns>List of ConsumedNutrients</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.ConsumedNutrient>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.ConsumedNutrient>>> GetConsumedNutrients()
        {
            return Ok((await _bll.ConsumedNutrients.GetAllNutrientsWithInfo(User.GetUserId()!.Value)).Select(s =>
                Mapper.Map<BLL.App.DTO.ConsumedNutrient, PublicApi.DTO.v1.ConsumedNutrient>(s)
));
        }

        // GET: api/ConsumedNutrients/5
        /// <summary>
        /// Get one ConsumedNutrient, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>ConsumedNutrient entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ConsumedNutrient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.ConsumedNutrient>> GetConsumedNutrient(Guid id)
        {
            var consumedNutrient = await _bll.ConsumedNutrients.FirstOrDefaultWithIncludesAsync(id, User.GetUserId()!.Value);

            if (consumedNutrient == null)
            {
                return NotFound();
            }
            
            /*var res = new PublicApi.DTO.v1.ConsumedNutrient()
            {
                Id = consumedNutrient.Id,
                NutrientId = consumedNutrient.NutrientId,
                Nutrient = consumedNutrient.Nutrient!.Title!,
                Date = consumedNutrient.Date,
                Quantity = consumedNutrient.Quantity
            };*/

            return Mapper.Map<BLL.App.DTO.ConsumedNutrient, PublicApi.DTO.v1.ConsumedNutrient>(consumedNutrient);
        }

        // PUT: api/ConsumedNutrients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one ConsumedNutrient, Based on parameters: Id, ConsumedNutrient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consumedNutrient"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ConsumedNutrient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutConsumedNutrient(Guid id, PublicApi.DTO.v1.ConsumedNutrientAddPut consumedNutrient)
        {
            if (id != consumedNutrient.Id)
            {
                return BadRequest();
            }

            var bllConsumedNutrient = ConsumedNutrientMapper.MapToBll(consumedNutrient);
            bllConsumedNutrient.AppUserId = User.GetUserId()!.Value;
            _bll.ConsumedNutrients.Update(bllConsumedNutrient);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ConsumedNutrients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add ConsumedNutrient, Based on request body: ConsumedNutrient
        /// </summary>
        /// <param name="consumedNutrient"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ConsumedNutrient), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ConsumedNutrient>> PostConsumedNutrient(PublicApi.DTO.v1.ConsumedNutrientAddPut consumedNutrient)
        {
            var bllConsumedNutrient = ConsumedNutrientMapper.MapToBll(consumedNutrient);
            bllConsumedNutrient.AppUserId = User.GetUserId()!.Value;
            var addedConsumedNutrient = _bll.ConsumedNutrients.Add(bllConsumedNutrient);
            await _bll.SaveChangesAsync();
            var returnConsumedNutrient = _consumedNutrientMapper.Map(addedConsumedNutrient);
            
            // this is sketchy af
            returnConsumedNutrient!.Nutrient = bllConsumedNutrient.NutrientName!;
            return CreatedAtAction("GetConsumedNutrient", new {id = returnConsumedNutrient!.Id}, returnConsumedNutrient);}

        // DELETE: api/ConsumedNutrients/5
        /// <summary>
        /// Delete ConsumedNutrient, Based on parameter: id
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
        public async Task<IActionResult> DeleteConsumedNutrient(Guid id)
        {
            var consumedNutrient = await _bll.ConsumedNutrients.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (consumedNutrient == null)
            {
                return NotFound();
            }
            _bll.ConsumedNutrients.Remove(consumedNutrient);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ConsumedNutrientExists(Guid id)
        {
            return await _bll.ConsumedNutrients.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
