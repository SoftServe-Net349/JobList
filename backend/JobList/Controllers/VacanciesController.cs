using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.Common.UrlQuery;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : Controller
    {
        private IVacanciesService _vacanciesService;

        public VacanciesController(IVacanciesService vacanciesService)
        {
            _vacanciesService = vacanciesService;
        }

        // GET: /vacancies
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get([FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _vacanciesService.GetRangeOfEntitiesAsync(paginationUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _vacanciesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get([FromQuery]VacancyUrlQuery vacancyUrlQuery, [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _vacanciesService.GetFilteredEntitiesAsync(vacancyUrlQuery, paginationUrlQuery);

            if (dtos == null)
            {
                return NotFound();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _vacanciesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            
            return Ok(dtos);
        }

        
        [HttpGet("admin")]
        public virtual async Task<ActionResult<IEnumerable<UserDTO>>> Get(string searchString, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _vacanciesService.GetFilteredEntitiesAsync(searchString, sortingUrlQuery, paginationUrlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _vacanciesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [HttpGet("recruiter/{id}")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetVacanciesByRecruiterId(int id)
        {
            var dtos = await _vacanciesService.GetVacanciesByRectuiterId(id);
            if (!dtos.Any())
            {
                return NoContent();
            }
            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<VacancyDTO>> GetById(int id)
        {
            var dto = await _vacanciesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /vacancies
        [HttpPost]
        public virtual async Task<ActionResult<VacancyDTO>> Create([FromBody] VacancyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _vacanciesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /vacancies/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]VacancyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _vacanciesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /vacancies/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _vacanciesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }

}
