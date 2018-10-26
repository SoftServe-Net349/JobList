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
    public class LanguagesController : Controller
    {
        private ILanguagesService _languagesService;

        public LanguagesController(ILanguagesService languagesService)
        {
            _languagesService = languagesService;
        }

        // GET: /languages
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<LanguageDTO>>> Get()
        {
            var dtos = await _languagesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<LanguageDTO>> GetById(int id)
        {
            var dto = await _languagesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /languages
        [Authorize(Roles = "admin")]
        [HttpPost]
        public virtual async Task<ActionResult<LanguageDTO>> Create([FromBody] LanguageRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _languagesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /languages/:id
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]LanguageRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _languagesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /languages/:id
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _languagesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

    }
}
