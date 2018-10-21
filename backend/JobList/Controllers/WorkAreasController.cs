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
    [Route("api/[controller]")]
    [ApiController]
    public class WorkAreasController : Controller
    {
        private IWorkAreasService _workAreasService;

        public WorkAreasController(IWorkAreasService workAreasService)
        {
            _workAreasService = workAreasService;
        }

        // GET: /workAreas
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<WorkAreaDTO>>> Get()
        {
            var dtos = await _workAreasService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<WorkAreaDTO>> GetById(int id)
        {
            var dto = await _workAreasService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /workAreas
        [Authorize(Roles = "admin")]
        [HttpPost]
        public virtual async Task<ActionResult<WorkAreaDTO>> Create([FromBody] WorkAreaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _workAreasService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /workAreas/:id
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]WorkAreaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _workAreasService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /workAreas/:id
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _workAreasService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
