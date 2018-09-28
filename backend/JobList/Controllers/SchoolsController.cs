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
    public class SchoolsController : Controller
    {
        private ISchoolsService _schoolsService;

        public SchoolsController(ISchoolsService schoolsService)
        {
            _schoolsService = schoolsService;
        }

        // GET: /schools
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<SchoolDTO>>> Get()
        {
            var dtos = await _schoolsService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<SchoolDTO>> GetById(int id)
        {
            var dto = await _schoolsService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /schools
        [HttpPost]
        public virtual async Task<ActionResult<SchoolDTO>> Create([FromBody] SchoolRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _schoolsService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /schools/:id
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]SchoolRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _schoolsService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /schools/:id
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _schoolsService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
