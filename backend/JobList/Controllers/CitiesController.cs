﻿using System.Collections.Generic;
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
    public class CitiesController : Controller
    {
        private ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        // GET: /cities
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<CityDTO>>> Get()
        {
            var dtos = await _citiesService.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<CityDTO>> GetById(int id)
        {
            var dto = await _citiesService.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /cities
        [Authorize(Roles = "admin")]
        [HttpPost]
        public virtual async Task<ActionResult<CityDTO>> Create([FromBody] CityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dtos = await _citiesService.CreateEntityAsync(request);
            if (dtos == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /cities/:id
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]CityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _citiesService.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /cities/:id
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _citiesService.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}