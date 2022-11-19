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
    [Authorize(Roles="customer, company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecipeTagsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private RecipeTagMapper _recipeTagMapper;

        public RecipeTagsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _recipeTagMapper = new RecipeTagMapper(Mapper);
        }

        // GET: api/RecipeTags
        /// <summary>
        /// Get all RecipeTags
        /// </summary>
        /// <returns>List of RecipeTags</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.RecipeTag>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<RecipeTag>>> GetRecipeTags()
        {
            return await _context.RecipeTags.ToListAsync();
        }

        // GET: api/RecipeTags/5
        /// <summary>
        /// Get one RecipeTag, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>RecipeTag entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.RecipeTag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<RecipeTag>> GetRecipeTag(Guid id)
        {
            var recipeTag = await _context.RecipeTags.FindAsync(id);

            if (recipeTag == null)
            {
                return NotFound();
            }

            return recipeTag;
        }

        // PUT: api/RecipeTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one RecipeTag, Based on parameters: Id, RecipeTag
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recipeTag"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.RecipeTag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutRecipeTag(Guid id, RecipeTag recipeTag)
        {
            if (id != recipeTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipeTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeTagExists(id))
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

        // POST: api/RecipeTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add RecipeTag, Based on request body: RecipeTag
        /// </summary>
        /// <param name="recipeTag"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.RecipeTag), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<RecipeTag>> PostRecipeTag(RecipeTag recipeTag)
        {
            _context.RecipeTags.Add(recipeTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeTag", new { id = recipeTag.Id }, recipeTag);
        }

        // DELETE: api/RecipeTags/5
        /// <summary>
        /// Delete RecipeTag, Based on parameter: id
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
        public async Task<IActionResult> DeleteRecipeTag(Guid id)
        {
            var recipeTag = await _context.RecipeTags.FindAsync(id);
            if (recipeTag == null)
            {
                return NotFound();
            }

            _context.RecipeTags.Remove(recipeTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeTagExists(Guid id)
        {
            return _context.RecipeTags.Any(e => e.Id == id);
        }
    }
}
*/
