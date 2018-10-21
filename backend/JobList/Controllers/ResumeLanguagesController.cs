using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.Authorization;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeLanguagesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IResumeLanguagesService _resumeLanguagesService;

        public ResumeLanguagesController(IResumeLanguagesService resumeLanguagesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _resumeLanguagesService = resumeLanguagesService;
        }

        // GET: /resumeLanguages
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<ResumeLanguageDTO>>> Get()
        {
            var dtos = await _resumeLanguagesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ResumeLanguageDTO>> GetById(int id)
        {
            var dto = await _resumeLanguagesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /resumeLanguages
        [Authorize(Roles = "employee, admin")]
        [HttpPost]
        public virtual async Task<ActionResult<ResumeLanguageDTO>> Create([FromBody] ResumeLanguageRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _resumeLanguagesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /resumeLanguages/:id
        [Authorize(Roles = "employee, admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]ResumeLanguageRequest request)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, request.ResumeId, UserOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _resumeLanguagesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /resumeLanguages/:id
        [Authorize(Roles = "employee, admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var entity = await _resumeLanguagesService.GetEntityByIdAsync(id);

            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, entity.ResumeId, UserOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var result = await _resumeLanguagesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
