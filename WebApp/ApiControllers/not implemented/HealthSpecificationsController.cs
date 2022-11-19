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

    public class HealthSpecificationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private HealthSpecificationMapper _healthSpecificationMapper;

        public HealthSpecificationsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _healthSpecificationMapper = new HealthSpecificationMapper(Mapper);
        }

        // GET: api/HealthSpecifications
        /// <summary>
        /// Get all HealthSpecifications
        /// </summary>
        /// <returns>List of HealthSpecifications</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.HealthSpecification>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<HealthSpecification>>> GetHealthSpecifications()
        {
            return await _context.HealthSpecifications.ToListAsync();
        }

        // GET: api/HealthSpecifications/5
        /// <summary>
        /// Get one HealthSpecification, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>HealthSpecification entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.HealthSpecification), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<HealthSpecification>> GetHealthSpecification(Guid id)
        {
            var healthSpecification = await _context.HealthSpecifications.FindAsync(id);

            if (healthSpecification == null)
            {
                return NotFound();
            }

            return healthSpecification;
        }

        // PUT: api/HealthSpecifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one HealthSpecification, Based on parameters: Id, HealthSpecification
        /// </summary>
        /// <param name="id"></param>
        /// <param name="healthSpecification"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.HealthSpecification), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutHealthSpecification(Guid id, HealthSpecification healthSpecification)
        {
            if (id != healthSpecification.Id)
            {
                return BadRequest();
            }

            _context.Entry(healthSpecification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthSpecificationExists(id))
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

        // POST: api/HealthSpecifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add HealthSpecification, Based on request body: HealthSpecification
        /// </summary>
        /// <param name="healthSpecification"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.HealthSpecification), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<HealthSpecification>> PostHealthSpecification(HealthSpecification healthSpecification)
        {
            _context.HealthSpecifications.Add(healthSpecification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHealthSpecification", new { id = healthSpecification.Id }, healthSpecification);
        }

        // DELETE: api/HealthSpecifications/5
        /// <summary>
        /// Delete HealthSpecification, Based on parameter: id
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
        public async Task<IActionResult> DeleteHealthSpecification(Guid id)
        {
            var healthSpecification = await _context.HealthSpecifications.FindAsync(id);
            if (healthSpecification == null)
            {
                return NotFound();
            }

            _context.HealthSpecifications.Remove(healthSpecification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HealthSpecificationExists(Guid id)
        {
            return _context.HealthSpecifications.Any(e => e.Id == id);
        }
    }
}
*/
