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
    [Authorize(Roles="customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonHealthSpecificationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private PersonHealthSpecificationMapper _personHealthSpecificationMapper;

        public PersonHealthSpecificationsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _personHealthSpecificationMapper = new PersonHealthSpecificationMapper(Mapper);
        }

        // GET: api/PersonHealthSpecifications
        /// <summary>
        /// Get all PersonHealthSpecifications
        /// </summary>
        /// <returns>List of PersonHealthSpecifications</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonHealthSpecification>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PersonHealthSpecification>>> GetPersonHealthSpecifications()
        {
            return await _context.PersonHealthSpecifications.ToListAsync();
        }

        // GET: api/PersonHealthSpecifications/5
        /// <summary>
        /// Get one PersonHealthSpecification, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>PersonHealthSpecification entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonHealthSpecification), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonHealthSpecification>> GetPersonHealthSpecification(Guid id)
        {
            var personHealthSpecification = await _context.PersonHealthSpecifications.FindAsync(id);

            if (personHealthSpecification == null)
            {
                return NotFound();
            }

            return personHealthSpecification;
        }

        // PUT: api/PersonHealthSpecifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one PersonHealthSpecification, Based on parameters: Id, PersonHealthSpecification
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personHealthSpecification"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonHealthSpecification), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutPersonHealthSpecification(Guid id, PersonHealthSpecification personHealthSpecification)
        {
            if (id != personHealthSpecification.Id)
            {
                return BadRequest();
            }

            _context.Entry(personHealthSpecification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonHealthSpecificationExists(id))
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

        // POST: api/PersonHealthSpecifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add PersonHealthSpecification, Based on request body: PersonHealthSpecification
        /// </summary>
        /// <param name="personHealthSpecification"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonHealthSpecification), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonHealthSpecification>> PostPersonHealthSpecification(PersonHealthSpecification personHealthSpecification)
        {
            _context.PersonHealthSpecifications.Add(personHealthSpecification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonHealthSpecification", new { id = personHealthSpecification.Id }, personHealthSpecification);
        }

        // DELETE: api/PersonHealthSpecifications/5
        /// <summary>
        /// Delete PersonHealthSpecification, Based on parameter: id
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
        public async Task<IActionResult> DeletePersonHealthSpecification(Guid id)
        {
            var personHealthSpecification = await _context.PersonHealthSpecifications.FindAsync(id);
            if (personHealthSpecification == null)
            {
                return NotFound();
            }

            _context.PersonHealthSpecifications.Remove(personHealthSpecification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonHealthSpecificationExists(Guid id)
        {
            return _context.PersonHealthSpecifications.Any(e => e.Id == id);
        }
    }
}
*/
