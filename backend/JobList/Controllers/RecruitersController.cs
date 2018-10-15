using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Pagination;
using JobList.Common.Requests;
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

        [HttpGet("company/{id}")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetRecruitersByCompanyId(int id, [FromQuery] PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _recruitersService.GetRecruitersByCompanyId(id, urlQuery);

            if (!dtos.Any())
            {
                return NoContent();
            }

            if (urlQuery != null)
            {
                var pageInfo = new PageInfo()
                {
                    PageNumber = urlQuery.PageNumber,
                    PageSize = urlQuery.PageSize,
                    TotalRecords = await _recruitersService.CountAsync(r => r.CompanyId == id)
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
            }

            return Ok(dtos);
        }

        [HttpGet("company/{id}/filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> GetFilteredRecruiters(int id, string recruiterName, [FromQuery]PaginationUrlQuery urlQuery = null)
        {
            var dtos = await _recruitersService.GetFilteredRecruiters(id, recruiterName, urlQuery);

            if (dtos == null)
            {
                return NotFound();
            }


            if (urlQuery != null)
            {
                var pageInfo = new PageInfo()
                {
                    PageNumber = urlQuery.PageNumber,
                    PageSize = urlQuery.PageSize,
                    TotalRecords = await _recruitersService.CountAsync(r => r.CompanyId == id && r.FirstName == recruiterName)
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));
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
