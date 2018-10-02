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
    public class VacanciesController : Controller
    {
        private IVacanciesService _vacanciesService;

        public VacanciesController(IVacanciesService vacanciesService)
        {
            _vacanciesService = vacanciesService;
        }

        // GET: /vacancies
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get()
        {
            var dtos = await _vacanciesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [HttpGet("search/{searchString}")]
        public virtual async Task<ActionResult<IEnumerable<VacancyDTO>>> Get(string searchString)
        {
            var dtos = await _vacanciesService.GetAllEntitiesAsync();
            
            if(dtos == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                dtos = dtos.Select(d => d)
                    .Where(d => d.Name.ToLower()
                    .Contains(searchString.ToLower()));
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
