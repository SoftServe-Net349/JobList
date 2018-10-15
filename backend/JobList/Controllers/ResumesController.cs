using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.UrlQuery;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : Controller
    {
        private IResumesService _resumesService;

        public ResumesController(IResumesService resumesService)
        {
            _resumesService = resumesService;
        }

        // GET: /resumes
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<ResumeDTO>>> Get([FromQuery] PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _resumesService.GetRangeOfEntitiesAsync(urlQuery);
            if (!dtos.Any())
            {
                return NoContent();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = urlQuery.PageNumber,
                PageSize = urlQuery.PageSize,
                TotalRecords = _resumesService.Count
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }


        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get([FromQuery]ResumeUrlQuery resumeUrlQuery, [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _resumesService.GetFilteredEntitiesAsync(resumeUrlQuery, paginationUrlQuery);

            if (dtos == null)
            {
                return NotFound();
            }

            if (paginationUrlQuery != null)
            {
                int count = dtos.Count();
                dtos = dtos.Skip(paginationUrlQuery.PageSize * (paginationUrlQuery.PageNumber - 1))
                    .Take(paginationUrlQuery.PageSize).ToList();

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
        public virtual async Task<ActionResult<ResumeDTO>> GetById(int id)
        {
            var dto = await _resumesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /resumes
        [HttpPost]
        public virtual async Task<ActionResult<ResumeDTO>> Create([FromBody] ResumeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _resumesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /resumes/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]ResumeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _resumesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /resumes/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _resumesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
