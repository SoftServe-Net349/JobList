using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitersController : Controller
    {
        private IRecruitersService _recruitersService;

        public RecruitersController(IRecruitersService recruitersService)
        {
            _recruitersService = recruitersService;
        }

        // GET: /recruiters
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> Get()
        {
            var dtos = await _recruitersService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [HttpGet("Admin")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> Get(string searchString, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _recruitersService.GetFilteredEntitiesAsync(searchString, sortingUrlQuery);
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

        [HttpGet("company/{id}")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetRecruitersByCompanyId(int id)
        {
            var dtos = await _recruitersService.GetRecruitersByCompanyId(id);

            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<RecruiterDTO>> GetById(int id)
        {
            var dto = await _recruitersService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /recruiters
        [HttpPost("register")]
        public virtual async Task<ActionResult<RecruiterDTO>> Register([FromBody] RecruiterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dtos = await _recruitersService.CreateEntityAsync(request);

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

        // PUT: /recruiters/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]RecruiterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _recruitersService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /recruiters/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _recruitersService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
