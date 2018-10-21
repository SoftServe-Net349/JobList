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

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IEmployeesService _employeesService;

        public employeesController(IEmployeesService employeesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _employeesService = employeesService;
        }

        // GET: /employees
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


        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetFiltered(string searchString, string searchField, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _employeesService.GetFilteredEntitiesAsync(searchString, searchField, sortingUrlQuery, paginationUrlQuery);
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

        [Authorize(Roles = "employee")]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var isAuthorized = await _authorizationService
                                .AuthorizeAsync(User, id, "OwnerPolicy");

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var dto = await _employeesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /employees
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
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]EmployeeRequest request)
        {
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
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _employeesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
