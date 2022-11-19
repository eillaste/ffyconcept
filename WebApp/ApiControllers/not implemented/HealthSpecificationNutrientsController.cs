/*
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PublicApi.DTO.v1.Mappers;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HealthSpecificationNutrientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private HealthSpecificationNutrientMapper _healthSpecificationNutrientMapper;

        public HealthSpecificationNutrientsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _healthSpecificationNutrientMapper = new HealthSpecificationNutrientMapper(Mapper);
        }

        // GET: api/HealthSpecificationNutrients
        /// <summary>
        /// Get all HealthSpecificationNutrients
        /// </summary>
        /// <returns>List of HealthSpecificationNutrients</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.HealthSpecificationNutrient>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<HealthSpecificationNutrient>>> GetHealthSpecificationNutrients()
        {
            return await _context.HealthSpecificationNutrients.ToListAsync();
        }

        // GET: api/HealthSpecificationNutrients/5
        /// <summary>
        /// Get one HealthSpecificationNutrient, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>HealthSpecificationNutrient entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.HealthSpecificationNutrient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<HealthSpecificationNutrient>> GetHealthSpecificationNutrient(Guid id)
        {
            var healthSpecificationNutrient = await _context.HealthSpecificationNutrients.FindAsync(id);

            if (healthSpecificationNutrient == null)
            {
                return NotFound();
            }

            return healthSpecificationNutrient;
        }

        // PUT: api/HealthSpecificationNutrients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one HealthSpecificationNutrient, Based on parameters: Id, HealthSpecificationNutrient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="healthSpecificationNutrient"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.HealthSpecificationNutrient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutHealthSpecificationNutrient(Guid id, HealthSpecificationNutrient healthSpecificationNutrient)
        {
            if (id != healthSpecificationNutrient.Id)
            {
                return BadRequest();
            }

            _context.Entry(healthSpecificationNutrient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthSpecificationNutrientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HealthSpecificationNutrients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add HealthSpecificationNutrient, Based on request body: HealthSpecificationNutrient
        /// </summary>
        /// <param name="healthSpecificationNutrient"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.HealthSpecificationNutrient), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<HealthSpecificationNutrient>> PostHealthSpecificationNutrient(HealthSpecificationNutrient healthSpecificationNutrient)
        {
            _context.HealthSpecificationNutrients.Add(healthSpecificationNutrient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHealthSpecificationNutrient", new { id = healthSpecificationNutrient.Id }, healthSpecificationNutrient);
        }

        // DELETE: api/HealthSpecificationNutrients/5
        /// <summary>
        /// Delete HealthSpecificationNutrient, Based on parameter: id
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
        public async Task<IActionResult> DeleteHealthSpecificationNutrient(Guid id)
        {
            var healthSpecificationNutrient = await _context.HealthSpecificationNutrients.FindAsync(id);
            if (healthSpecificationNutrient == null)
            {
                return NotFound();
            }

            _context.HealthSpecificationNutrients.Remove(healthSpecificationNutrient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HealthSpecificationNutrientExists(Guid id)
        {
            return _context.HealthSpecificationNutrients.Any(e => e.Id == id);
        }
    }
}
*/
