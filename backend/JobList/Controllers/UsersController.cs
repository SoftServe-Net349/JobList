using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: /users
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<UserDTO>>> Get(string searchString, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _usersService.GetFilteredEntitiesAsync(searchString, sortingUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            if (paginationUrlQuery != null)
            {
                int count = dtos.Count();

                dtos = dtos.Skip(paginationUrlQuery.PageSize * (paginationUrlQuery.PageNumber - 1))
                    .Take(paginationUrlQuery.PageSize)
                    .ToList();

                var pageInfo = new PageInfo()
                {
                    PageNumber = paginationUrlQuery.PageNumber,
                    PageSize = paginationUrlQuery.PageSize,
                    TotalRecords = count
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            }

            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var dto = await _usersService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /users
        [HttpPost]
        public virtual async Task<ActionResult<UserDTO>> Create([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _usersService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
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
