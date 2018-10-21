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
    public class FavoriteVacanciesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private IFavoriteVacanciesService _favoriteVacanciesService;

        public FavoriteVacanciesController(IFavoriteVacanciesService favoriteVacanciesService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _favoriteVacanciesService = favoriteVacanciesService;
        }

        // GET: /favoriteVacancies
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<FavoriteVacancyDTO>>> Get()
        {
            var dtos = await _favoriteVacanciesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<FavoriteVacancyDTO>> GetById(int id)
        {
            var dto = await _favoriteVacanciesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /favoriteVacancies
        [Authorize(Roles = "employee, admin")]
        [HttpPost]
        public virtual async Task<ActionResult<FavoriteVacancyDTO>> Create([FromBody] FavoriteVacancyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _favoriteVacanciesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /favoriteVacancies/:id
        [Authorize(Roles = "employee, admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]FavoriteVacancyRequest request)
        {
            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, request.EmployeeId, UserOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _favoriteVacanciesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /favoriteVacancies/:id
        [Authorize(Roles = "employee, admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var entity = await _favoriteVacanciesService.GetEntityByIdAsync(id);

            var isAuthorized = await _authorizationService
                    .AuthorizeAsync(User, entity.EmployeerId, UserOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var result = await _favoriteVacanciesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
