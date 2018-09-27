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
    public class EducationPeriodsController : Controller
    {
        private IEducationPeriodsService _educationPeriodsService;

        public EducationPeriodsController(IEducationPeriodsService educationPeriodsService)
        {
            _educationPeriodsService = educationPeriodsService;
        }

        // GET: /educationPeriods
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<EducationPeriodDTO>>> Get()
        {
            var dtos = await _educationPeriodsService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<EducationPeriodDTO>> GetById(int id)
        {
            var dto = await _educationPeriodsService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /educationPeriods
        [HttpPost]
        public virtual async Task<ActionResult<EducationPeriodDTO>> Create([FromBody] EducationPeriodRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _educationPeriodsService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /educationPeriods/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]EducationPeriodRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _educationPeriodsService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /educationPeriods/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _educationPeriodsService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
