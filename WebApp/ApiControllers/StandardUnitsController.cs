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
    public class StandardUnitsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper Mapper;
        private StandardUnitMapper _standardUnitMapper;

        public StandardUnitsController(AppDbContext context, IAppUnitOfWork uow, IAppBLL bll, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _bll = bll;
            Mapper = mapper;
            _standardUnitMapper = new StandardUnitMapper(Mapper);
        }

        // GET: api/StandardUnits
        /// <summary>
        /// Get all StandardUnits
        /// </summary>
        /// <returns>List of StandardUnits</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.v1.StandardUnit>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.StandardUnit>>> GetStandardUnits()
        {
            return Ok((await _bll.StandardUnits.GetAllAsync()).Select(s => 
                Mapper.Map<BLL.App.DTO.StandardUnit, PublicApi.DTO.v1.StandardUnit>(s)
));
        }

        // GET: api/StandardUnits/5
        /// <summary>
        /// Get one StandardUnit, Based on parameter: Id
        /// </summary>
        /// <param name="id">Id of object to retrieve, Guid</param>
        /// <returns>StandardUnit entity from db </returns>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.StandardUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[AllowAnonymous]
        public async Task<ActionResult<PublicApi.DTO.v1.StandardUnit>> GetStandardUnit(Guid id)
        {
            // previously var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(id);

            if (standardUnit == null)
            {
                return NotFound();
            }
            
            /*var res = new PublicApi.DTO.v1.StandardUnit()
            {
                Id = standardUnit.Id,
                Title = standardUnit.Title,
                Symbol = standardUnit.Symbol
            };*/
            

            return Mapper.Map<BLL.App.DTO.StandardUnit, PublicApi.DTO.v1.StandardUnit>(standardUnit);
        }

        // PUT: api/StandardUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Edit one StandardUnit, Based on parameters: Id, StandardUnit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="standardUnit"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.StandardUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutStandardUnit(Guid id, PublicApi.DTO.v1.StandardUnitAddPut standardUnit)
        {
            if (id != standardUnit.Id)
            {
                return BadRequest();
            }

            var bllStandardUnit = StandardUnitMapper.MapToBll(standardUnit);
            Console.WriteLine(bllStandardUnit.Id);
            Console.WriteLine(bllStandardUnit.Title);
            Console.WriteLine(bllStandardUnit.Symbol);
            _bll.StandardUnits.Update(bllStandardUnit);
            Console.WriteLine("GOGOGO");
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/StandardUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add StandardUnit, Based on request body: StandardUnit
        /// </summary>
        /// <param name="standardUnit"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.StandardUnit), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<StandardUnit>> PostStandardUnit(PublicApi.DTO.v1.StandardUnitAddPut standardUnit)
        {
            var bllStandardUnit = StandardUnitMapper.MapToBll(standardUnit);
            //bllAgeGroup.AppUserId = User.GetUserId()!.Value;
            var addedStandardUnit = _bll.StandardUnits.Add(bllStandardUnit);
            await _bll.SaveChangesAsync();
            var returnStandardUnit = _standardUnitMapper.Map(addedStandardUnit);
            
            // this is sketchy af
            //returnStandardUnit!.Range = bllAgeGroup.LowerBound + "-" + bllAgeGroup.UpperBound;
            return CreatedAtAction("GetStandardUnit", new {id = returnStandardUnit!.Id}, returnStandardUnit);
        }

        // DELETE: api/StandardUnits/5
        /// <summary>
        /// Delete StandardUnit, Based on parameter: id
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
        public async Task<IActionResult> DeleteStandardUnit(Guid id)
        {
            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(id,User.GetUserId()!.Value);
            if (standardUnit == null)
            {
                return NotFound();
            }

            _bll.StandardUnits.Remove(standardUnit);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> StandardUnitExists(Guid id)
        {
            return await _bll.StandardUnits.ExistsAsync(id,User.GetUserId()!.Value);
        }
    }
}
