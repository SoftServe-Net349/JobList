using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.Authorization;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.UrlQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IResumesService _resumesService;

        public ResumesController(IResumesService resumesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _resumesService = resumesService;
        }

        // GET: /resumes
        [Authorize(Roles = "company, recruiter, admin")]
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
                TotalRecords = await _resumesService.CountAsync()
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }

        [Authorize(Roles = "company, recruiter, admin")]
        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get([FromQuery]ResumeUrlQuery resumeUrlQuery, [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
       {
            var dtos = await _resumesService.GetFilteredEntitiesAsync(resumeUrlQuery, paginationUrlQuery);

            if (dtos == null)
            {
                return NotFound();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = paginationUrlQuery.PageNumber,
                PageSize = paginationUrlQuery.PageSize,
                TotalRecords = _resumesService.TotalRecords
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageInfo));

            return Ok(dtos);
        }
 

        [Authorize]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ResumeDTO>> GetById(int id)
        {
            if (User.IsInRole("employee"))
            {
                var isAuthorized = await _authorizationService
                                    .AuthorizeAsync(User, id, UserOperations.Update);

                if (!isAuthorized.Succeeded)
                {
                    return Forbid();
                }
            }
            try
            {
                var dto = await _resumesService.GetEntityByIdAsync(id);
                if (dto == null)
                {
                    return NotFound();
                }
                return Ok(dto);
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: /resumes
        [Authorize(Roles = "employee, admin")]
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
        [Authorize(Roles = "employee, admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]ResumeRequest request)
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

            var result = await _resumesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /resumes/:id
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

            var result = await _resumesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
