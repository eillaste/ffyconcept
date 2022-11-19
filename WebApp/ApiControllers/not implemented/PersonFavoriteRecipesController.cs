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
    public class PersonFavoriteRecipesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private PersonFavoriteRecipeMapper _personFavoriteRecipeMapper;

        public PersonFavoriteRecipesController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _personFavoriteRecipeMapper = new PersonFavoriteRecipeMapper(Mapper);
        }

        // GET: api/PersonFavoriteRecipes
        /// <summary>
        /// Get all PersonFavoriteRecipes
        /// </summary>
        /// <returns>List of PersonFavoriteRecipes</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.PersonFavoriteRecipe>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PersonFavoriteRecipe>>> GetPersonFavoriteRecipes()
        {
            return await _context.PersonFavoriteRecipes.ToListAsync();
        }

        // GET: api/PersonFavoriteRecipes/5
        /// <summary>
        /// Get one PersonFavoriteRecipe, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>PersonFavoriteRecipe entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonFavoriteRecipe), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonFavoriteRecipe>> GetPersonFavoriteRecipe(Guid id)
        {
            var personFavoriteRecipe = await _context.PersonFavoriteRecipes.FindAsync(id);

            if (personFavoriteRecipe == null)
            {
                return NotFound();
            }

            return personFavoriteRecipe;
        }

        // PUT: api/PersonFavoriteRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one PersonFavoriteRecipe, Based on parameters: Id, PersonFavoriteRecipe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personFavoriteRecipe"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonFavoriteRecipe), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutPersonFavoriteRecipe(Guid id, PersonFavoriteRecipe personFavoriteRecipe)
        {
            if (id != personFavoriteRecipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(personFavoriteRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonFavoriteRecipeExists(id))
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

        // POST: api/PersonFavoriteRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add PersonFavoriteRecipe, Based on request body: PersonFavoriteRecipe
        /// </summary>
        /// <param name="personFavoriteRecipe"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PersonFavoriteRecipe), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PersonFavoriteRecipe>> PostPersonFavoriteRecipe(PersonFavoriteRecipe personFavoriteRecipe)
        {
            _context.PersonFavoriteRecipes.Add(personFavoriteRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonFavoriteRecipe", new { id = personFavoriteRecipe.Id }, personFavoriteRecipe);
        }

        // DELETE: api/PersonFavoriteRecipes/5
        /// <summary>
        /// Delete PersonFavoriteRecipe, Based on parameter: id
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
        public async Task<IActionResult> DeletePersonFavoriteRecipe(Guid id)
        {
            var personFavoriteRecipe = await _context.PersonFavoriteRecipes.FindAsync(id);
            if (personFavoriteRecipe == null)
            {
                return NotFound();
            }

            _context.PersonFavoriteRecipes.Remove(personFavoriteRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonFavoriteRecipeExists(Guid id)
        {
            return _context.PersonFavoriteRecipes.Any(e => e.Id == id);
        }
    }
}
*/
