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
    public class PersonRecommendedDietaryIntakeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private PersonRecommendedDietaryIntakeMapper _personRecommendedDietaryIntakeMapper;

        public PersonRecommendedDietaryIntakeController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _personRecommendedDietaryIntakeMapper = new PersonRecommendedDietaryIntakeMapper(Mapper);
        }

        /*
        // GET: api/PersonRecommendedDietaryIntake
        /// <summary>
        /// Get all PersonRecommendedDietaryIntake
        /// </summary>
        /// <returns>List of PersonRecommendedDietaryIntake</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonRecommendedDietaryIntake>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PersonRecommendedDietaryIntake>>> GetPersonRecommendedDietaryIntake()
        {
            return await _context.PersonRecommendedDietaryIntake.ToListAsync();
        }

        // GET: api/PersonRecommendedDietaryIntake/5
        /// <summary>
        /// Get one PersonRecommendedDietaryIntake, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>PersonRecommendedDietaryIntake entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonRecommendedDietaryIntake), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonRecommendedDietaryIntake>> GetPersonRecommendedDietaryIntake(Guid id)
        {
            var personRecommendedDietaryIntake = await _context.PersonRecommendedDietaryIntake.FindAsync(id);

            if (personRecommendedDietaryIntake == null)
            {
                return NotFound();
            }

            return personRecommendedDietaryIntake;
        }

        // PUT: api/PersonRecommendedDietaryIntake/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one PersonRecommendedDietaryIntake, Based on parameters: Id, PersonRecommendedDietaryIntake
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personRecommendedDietaryIntake"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonRecommendedDietaryIntake), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutPersonRecommendedDietaryIntake(Guid id, PersonRecommendedDietaryIntake personRecommendedDietaryIntake)
        {
            if (id != personRecommendedDietaryIntake.Id)
            {
                return BadRequest();
            }

            _context.Entry(personRecommendedDietaryIntake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonRecommendedDietaryIntakeExists(id))
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

        // POST: api/PersonRecommendedDietaryIntake
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add PersonRecommendedDietaryIntake, Based on request body: PersonRecommendedDietaryIntake
        /// </summary>
        /// <param name="personRecommendedDietaryIntake"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonRecommendedDietaryIntake), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonRecommendedDietaryIntake>> PostPersonRecommendedDietaryIntake(PersonRecommendedDietaryIntake personRecommendedDietaryIntake)
        {
            _context.PersonRecommendedDietaryIntake.Add(personRecommendedDietaryIntake);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonRecommendedDietaryIntake", new { id = personRecommendedDietaryIntake.Id }, personRecommendedDietaryIntake);
        }

        // DELETE: api/PersonRecommendedDietaryIntake/5
        /// <summary>
        /// Delete PersonRecommendedDietaryIntake, Based on parameter: id
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
        public async Task<IActionResult> DeletePersonRecommendedDietaryIntake(Guid id)
        {
            var personRecommendedDietaryIntake = await _context.PersonRecommendedDietaryIntake.FindAsync(id);
            if (personRecommendedDietaryIntake == null)
            {
                return NotFound();
            }

            _context.PersonRecommendedDietaryIntake.Remove(personRecommendedDietaryIntake);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonRecommendedDietaryIntakeExists(Guid id)
        {
            return _context.PersonRecommendedDietaryIntake.Any(e => e.Id == id);
        }*/
    }
}
