using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JobList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FacultiesController : Controller
    {
        private IFacultiesService _facultiesService;

        public FacultiesController(IFacultiesService facultiesService)
        {
            _facultiesService = facultiesService;
        }

        // GET: /faculties
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<FacultyDTO>>> Get()
        {
            var dtos = await _facultiesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<FacultyDTO>> GetById(int id)
        {
            var dto = await _facultiesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /faculties
        [Authorize(Roles = "admin")]
        [HttpPost]
        public virtual async Task<ActionResult<FacultyDTO>> Create([FromBody] FacultyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _facultiesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /faculties/:id
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]FacultyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _facultiesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /faculties/:id
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _facultiesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
