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
using ConsumedFoodItem = BLL.App.DTO.ConsumedFoodItem;
using ConsumedNutrient = BLL.App.DTO.ConsumedNutrient;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles="company,customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecipesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private RecipeMapper _recipeMapper;

        public RecipesController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _recipeMapper = new RecipeMapper(Mapper);
        }

        // GET: api/Recipes
        /// <summary>
        /// Get all Recipes
        /// </summary>
        /// <returns>List of Recipes</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Recipe>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "company,admin,customer", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Recipe>>> GetRecipes()
        {
            return Ok((await _bll.Recipes.GetAllAsync()).Select(s => 
                Mapper.Map<BLL.App.DTO.Recipe, PublicApi.DTO.v1.Recipe>(s)
));
        }

        // GET: api/Recipes/5
        /// <summary>
        /// Get one Recipe, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>Recipe entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Recipe), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "admin,customer,company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PublicApi.DTO.v1.Recipe>> GetRecipe(Guid id)
        {
            var recipe = await _bll.Recipes.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (recipe == null)
            {
                return NotFound();
            }

            /*var res = new PublicApi.DTO.v1.Recipe()
            {
                Id = recipe.Id,
                AppUserId = recipe.AppUserId,
                Description = recipe.Description,
                Instructions = recipe.Instructions,
                Servings = recipe.Servings,
                PrepTime = recipe.PrepTime,
                RestaurantRecipe = recipe.RestaurantRecipe,
                Image = recipe.Image
            };*/

            return Mapper.Map<BLL.App.DTO.Recipe, PublicApi.DTO.v1.Recipe>(recipe);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one Recipe, Based on parameters: Id, Recipe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Recipe), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutRecipe(Guid id, PublicApi.DTO.v1.RecipeAddPut recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            var bllRecipe = RecipeMapper.MapToBll(recipe);
            _bll.Recipes.Update(bllRecipe);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add Recipe, Based on request body: Recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Recipe), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Recipe>> PostRecipe(PublicApi.DTO.v1.RecipeAddPut recipe)
        {
            Console.WriteLine("Post");
            var bllRecipe = RecipeMapper.MapToBll(recipe);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedRecipe = _bll.Recipes.Add(bllRecipe);
            await _bll.SaveChangesAsync();
            var returnRecipe = _recipeMapper.Map(addedRecipe);

            // this is sketchy af
            //returnAgeGroup!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetRecipe", new {id = returnRecipe!.Id}, returnRecipe);
        }

        // DELETE: api/Recipes/5
        /// <summary>
        /// Delete Recipe, Based on parameter: id
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
        [Authorize(Roles = "company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            var recipe = await _bll.Recipes.FirstOrDefaultAsync(id, User.GetUserId()!.Value);
            if (recipe == null)
            {
                return NotFound();
            }

            _bll.Recipes.Remove(recipe);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> RecipeExists(Guid id)
        {
            return await _bll.Recipes.ExistsAsync(id, User.GetUserId()!.Value);
        }


        /*public IActionResult Index2()
        {
            throw new NotImplementedException();
        }*/


        // GET: api/Recipes/RegisterMeal/5
        /// <summary>
        /// Get one Recipe, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>Recipe entity from db </returns>
        [HttpGet("registermeal/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Recipe), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "admin,customer,company", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<NoContentResult> RegisterMeal(Guid id)
        {
            Console.WriteLine(id);
            // create nutrient map
            Dictionary<Guid, double> foodItemMap = new Dictionary<Guid, double>();
            Dictionary<Guid, double> nutrientMap = new Dictionary<Guid, double>();

            
            // get ahold of appuser
            Console.WriteLine(id);
            var appuserId = User.GetUserId()!.Value;
            var recipe = await _bll.Recipes.FirstOrDefaultWithIncludesAsync(id, appuserId, true);
            Console.WriteLine(recipe);
            Console.WriteLine(recipe!.Description);
            Console.WriteLine(recipe!.Ingredients!.Count);
            Console.WriteLine("In " + recipe.Description + " there are " + recipe!.Ingredients.Count + " ingredients");
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!foodItemMap.ContainsKey(ingredient.FoodItemId))
                {
                    foodItemMap[ingredient.FoodItemId] = ingredient.Quantity;
                }
                else
                {
                    foodItemMap[ingredient.FoodItemId] = foodItemMap[ingredient.FoodItemId] + ingredient.Quantity;
                }
                
                
                Console.WriteLine(ingredient.Quantity + " " + ingredient.FoodItem!.StandardUnit!.Title +  " of " + ingredient.FoodItem!.Title + " which contains: ");
                foreach (var nutrientInFoodItem in ingredient.FoodItem!.NutrientInFoodItems!)
                {
                    if (!nutrientMap.ContainsKey(nutrientInFoodItem.NutrientId))
                    {
                        nutrientMap[nutrientInFoodItem.NutrientId] = nutrientInFoodItem.Quantity * ingredient.Quantity;
                    }
                    else
                    {
                        nutrientMap[nutrientInFoodItem.NutrientId] = nutrientMap[nutrientInFoodItem.NutrientId] + nutrientInFoodItem.Quantity * ingredient.Quantity;
                    }
                    Console.WriteLine(nutrientInFoodItem.Quantity * ingredient.Quantity + " " + nutrientInFoodItem.Nutrient!.StandardUnit!.Title + " of " + nutrientInFoodItem.Nutrient!.Title);
                }
                Console.WriteLine("--------");
            }
            Console.WriteLine("Meal registered");
            Console.WriteLine(foodItemMap.Count);
            foodItemMap.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            Console.WriteLine(nutrientMap.Count);
            nutrientMap.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);

            foreach (var keyValuePair in foodItemMap)
            {
                _bll.ConsumedFoodItems.Add(new ConsumedFoodItem()
                {
                    AppUserId = User.GetUserId()!.Value,
                    FoodItemId = keyValuePair.Key,
                    Quantity = keyValuePair.Value,
                    Date = DateTime.Now
                });
            }
            await _bll.SaveChangesAsync();
            foreach (var keyValuePair in nutrientMap)
            {
                _bll.ConsumedNutrients.Add(new ConsumedNutrient()
                {
                    AppUserId = User.GetUserId()!.Value,
                    NutrientId = keyValuePair.Key,
                    Quantity = keyValuePair.Value,
                    Date = DateTime.Now
                });
            }
            
            await _bll.SaveChangesAsync();
            /*IEnumerable<BLL.App.DTO.Recipe> res = null!;
            if (User.IsInRole("customer"))
            {
                res = await _bll.Recipes.GetAllAsync();
            } else if (User.IsInRole("company"))
            {
                res = await _bll.Recipes.GetAllAsync(User.GetUserId()!.Value);
            }
            await _bll.SaveChangesAsync();*/
            //return RedirectToAction(nameof(Index));
            return NoContent();
        }



       
        
    }
}