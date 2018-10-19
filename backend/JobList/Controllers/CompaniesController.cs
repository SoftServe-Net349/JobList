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
    public class CompaniesController : Controller
    {
        private ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        // GET: /companies
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<CompanyDTO>>> Get()
        {
            var dtos = await _companiesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }


        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> Get(string searchString, 
                                                                               [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                               [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _companiesService.GetFilteredEntitiesAsync(searchString, sortingUrlQuery, paginationUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _companiesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<CompanyDTO>> GetById(int id)
        {
            var dto = await _companiesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /companies
        [HttpPost("register")]
        public virtual async Task<ActionResult<CompanyDTO>> Register([FromBody] CompanyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dtos = await _companiesService.CreateEntityAsync(request);

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

        // PUT: /companies/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]CompanyUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _companiesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /companies/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _companiesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
