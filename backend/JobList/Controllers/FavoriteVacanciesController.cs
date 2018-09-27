using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Mvc;


namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteVacanciesController : Controller
    {
        private IFavoriteVacanciesService _favoriteVacanciesService;

        public FavoriteVacanciesController(IFavoriteVacanciesService favoriteVacanciesService)
        {
            _favoriteVacanciesService = favoriteVacanciesService;
        }

        // GET: /favoriteVacancies
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
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]FavoriteVacancyRequest request)
        {
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
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _favoriteVacanciesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
