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
    [Authorize(Roles="admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private CategoryMapper _categoryMapper;

        public CategoriesController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _categoryMapper = new CategoryMapper(Mapper);
        }

        // GET: api/Categories
        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>List of Categories</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Category>>> GetCategories()
        {
            return Ok((await _bll.Categories.GetAllAsync()).Select(s => Mapper.Map<BLL.App.DTO.Category, PublicApi.DTO.v1.Category>(s)
            ));
        }

        // GET: api/Categories/5
        /// <summary>
        /// Get one Category, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>Category entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.Category>> GetCategory(Guid id)
        {
            var category = await _bll.Categories.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (category == null)
            {
                return NotFound();
            }
            
            /*var res = new PublicApi.DTO.v1.Category()
            {
                Id = category.Id,
                Title = category.Title
            };*/

            return Mapper.Map<BLL.App.DTO.Category, PublicApi.DTO.v1.Category>(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one Category, Based on parameters: Id, Category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutCategory(Guid id, PublicApi.DTO.v1.CategoryAddPut category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var bllCategory = CategoryMapper.MapToBll(category);

            _bll.Categories.Update(bllCategory);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add Category, Based on request body: Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Category), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PublicApi.DTO.v1.Category>> PostCategory(PublicApi.DTO.v1.CategoryAddPut category)
        {
            var bllCategory = CategoryMapper.MapToBll(category);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedCategory = _bll.Categories.Add(bllCategory);
            await _bll.SaveChangesAsync();
            var returnCategory = _categoryMapper.Map(addedCategory);
            
            // this is sketchy af
            //returnCategory!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetCategory", new {id = returnCategory!.Id}, returnCategory);
        }

        // DELETE: api/Categories/5
        /// <summary>
        /// Delete Category, Based on parameter: id
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
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _bll.Categories.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (category == null)
            {
                return NotFound();
            }

            _bll.Categories.Remove(category);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CategoryExists(Guid id)
        {
            return await _bll.Categories.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
