using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Requests;
using JobList.Common.Pagination;
using JobList.Common.Sorting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using JobList.Authorization;
using JobList.Common.UrlQuery;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _employeesService = employeesService;
        }

        // GET: /employees
        [Authorize]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            var dtos = await _employeesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }
      
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetFiltered([FromQuery]SearchingUrlQuery searchingUrlQuery = null, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _employeesService.GetFilteredEntitiesAsync(searchingUrlQuery, sortingUrlQuery, paginationUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }


            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _employeesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var dto = await _employeesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /employees
        [AllowAnonymous]
        [HttpPost("register")]
        public virtual async Task<ActionResult<EmployeeDTO>> Register([FromBody] EmployeeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dtos = await _employeesService.CreateEntityAsync(request);

                if (dtos == null)
                {
                    return StatusCode(500);
                }

                return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: /employees/:id
        [Authorize(Roles = "employee, admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]EmployeeUpdateRequest request)
        {
            var isAuthorized = await _authorizationService
                                .AuthorizeAsync(User, id, UserOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _employeesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /employees/:id
        [Authorize(Roles = "employee, admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var isAuthorized = await _authorizationService
                                .AuthorizeAsync(User, id, UserOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var result = await _employeesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
