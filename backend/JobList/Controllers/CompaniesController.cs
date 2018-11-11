using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.Authorization;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using Microsoft.AspNetCore.Authorization;
using JobList.Common.UrlQuery;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JobList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompaniesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _companiesService = companiesService;
        }

        // GET: /companies
        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet("filtered")]
        public virtual async Task<ActionResult<IEnumerable<RecruiterDTO>>> Get([FromQuery]SearchingUrlQuery searchingUrlQuery = null, [FromQuery]SortingUrlQuery sortingUrlQuery = null,
                                                                            [FromQuery]PaginationUrlQuery paginationUrlQuery = null)
        {
            var dtos = await _companiesService.GetFilteredEntitiesAsync(searchingUrlQuery, sortingUrlQuery, paginationUrlQuery);
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

        [AllowAnonymous]
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
        [AllowAnonymous]
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
                    return StatusCode(500, "Sth went wrong. Please try again!");
                }

                return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: /companies/:id
        [Authorize(Roles = "company, admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]CompanyUpdateRequest request)
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

            var result = await _companiesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /companies/:id
        [Authorize(Roles = "company, admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, id, UserOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var result = await _companiesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
        [Authorize(Roles = "company")]
        [HttpPut("{id}/reset")]
        public virtual async Task<ActionResult> ResetPassword([FromRoute]int id, [FromBody]CompanyResetPasswordRequest request)
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
            try
            {
                var result = await _companiesService.ResetEntityByIdAsync(request, id);
                if (!result)
                {
                    return StatusCode(500);
                }

                return NoContent();
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
