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
    [Authorize(Roles="admin, customer, company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class IngredientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private IngredientMapper _ingredientMapper;

        public IngredientsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _ingredientMapper = new IngredientMapper(Mapper);
        }

        // GET: api/Ingredients
        /// <summary>
        /// Get all Ingredients
        /// </summary>
        /// <returns>List of Ingredients</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Ingredient>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Ingredient>>> GetIngredients()
        {
            return Ok((await _bll.Ingredients.GetAllAsync()).Select(s => 
                Mapper.Map<BLL.App.DTO.Ingredient, PublicApi.DTO.v1.Ingredient>(s)
));
        }

        // GET: api/Ingredients/5
        /// <summary>
        /// Get one Ingredient, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>Ingredient entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Ingredient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.Ingredient>> GetIngredient(Guid id)
        {
            var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (ingredient == null)
            {
                return NotFound();
            }

            /*var res = new PublicApi.DTO.v1.Ingredient()
            {
                Id=ingredient.Id,
                AppUserId = ingredient.AppUserId,
                FoodItemId = ingredient.FoodItemId,
                RecipeId = ingredient.RecipeId,
                Quantity = ingredient.Quantity
            };*/
            
            return Mapper.Map<BLL.App.DTO.Ingredient, PublicApi.DTO.v1.Ingredient>(ingredient);
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one Ingredient, Based on parameters: Id, Ingredient
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Ingredient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutIngredient(Guid id, PublicApi.DTO.v1.IngredientAddPut ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            var bllIngredient = IngredientMapper.MapToBll(ingredient);

            _bll.Ingredients.Update(bllIngredient);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add Ingredient, Based on request body: Ingredient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Ingredient), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.Ingredient>> PostIngredient(PublicApi.DTO.v1.IngredientAddPut ingredient)
        {
            var bllIngredient = IngredientMapper.MapToBll(ingredient);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedIngredient = _bll.Ingredients.Add(bllIngredient);
            await _bll.SaveChangesAsync();
            var returnIngredient = _ingredientMapper.Map(addedIngredient);
            
            // this is sketchy af
           // returnIngredient!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetIngredient", new {id = returnIngredient!.Id}, returnIngredient);
        }

        // DELETE: api/Ingredients/5
        /// <summary>
        /// Delete Ingredient, Based on parameter: id
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
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (ingredient == null)
            {
                return NotFound();
            }

            _bll.Ingredients.Remove(ingredient);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> IngredientExists(Guid id)
        {
            return await _bll.Ingredients.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
