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
    [Route("[controller]")]
    [ApiController]
    public class ExperiencesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IExperiencesService _experiencesService;

        public ExperiencesController(IExperiencesService experiencesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _experiencesService = experiencesService;
        }

        // GET: /experiences
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<ExperienceDTO>>> Get()
        {
            var dtos = await _experiencesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ExperienceDTO>> GetById(int id)
        {
            var dto = await _experiencesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /experiences
        [Authorize(Roles = "employee, admin")]
        [HttpPost]
        public virtual async Task<ActionResult<ExperienceDTO>> Create([FromBody] ExperienceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _experiencesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /experiences/:id
        [Authorize(Roles = "employee, admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]ExperienceRequest request)
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

            var result = await _experiencesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /experiences/:id
        [Authorize(Roles = "employee, admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var entity = await _experiencesService.GetEntityByIdAsync(id);

            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, entity.ResumeId, UserOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var result = await _experiencesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
