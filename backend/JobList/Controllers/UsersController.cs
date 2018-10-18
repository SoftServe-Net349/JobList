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
    public class UsersController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IUsersService _usersService;

        public UsersController(IUsersService usersService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _usersService = usersService;
        }

        // GET: /users
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var dtos = await _usersService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }
      
            return Ok(dtos);
        }


        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<UserDTO>>> GetFiltered(string searchString, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _usersService.GetFilteredEntitiesAsync(searchString, sortingUrlQuery, paginationUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }


            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _usersService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [Authorize(Roles = "user")]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var isAuthorized = await _authorizationService
                                .AuthorizeAsync(User, id, "OwnerPolicy");

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var dto = await _usersService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /users
        [HttpPost("register")]
        public virtual async Task<ActionResult<UserDTO>> Register([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dtos = await _usersService.CreateEntityAsync(request);

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

        // PUT: /users/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _usersService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /users/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _usersService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
