﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using JobList.BusinessLogic.Interfaces;
//using JobList.Common.DTOS;
//using JobList.Common.Requests;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace JobList.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SamplesController : ControllerBase
//    {
//        /// <summary>
//        /// The Samples Service service
//        /// </summary>
//        private readonly ISamplesService _samplesService;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="SamplesController"/> class. 
//        /// </summary>
//        /// <param name="service">
//        /// Samples service
//        /// </param>
//        public SamplesController(ISamplesService service)
//        {
//            _samplesService = service;
//        }

//        /// <summary>
//        /// Get Samples
//        /// </summary>
//        /// <returns>
//        /// List of Dtos of Samples
//        /// </returns>
//        /// <response code="500">Internal error on server</response>
//        /// <response code="404">Samples not found</response>
//        /// <response code="403">You don`t have permission to create watch Samples</response>
//        /// <response code="400">Model is not valid</response>
//        /// <response code="200">Success</response>
//        [HttpGet]
//        [AllowAnonymous]
//        public virtual async Task<ActionResult<IEnumerable<SampleDTO>>> Get()
//        {
//            var dtos = await _samplesService.GetAllEntitiesAsync();
//            if (!dtos.Any())
//            {
//                return NoContent();
//            }

//            return Ok(dtos);
//        }

//        /// <summary>
//        /// Get Sample by id
//        /// </summary>
//        /// <param name="id">Sample identifier</param>
//        /// <returns>
//        /// Dto of Sample
//        /// </returns>
//        /// <response code="500">Internal error on server</response>
//        /// <response code="404">Samples not found</response>
//        /// <response code="403">You don`t have permission to create watch Sample</response>
//        /// <response code="400">Model is not valid</response>
//        /// <response code="200">Success</response>
//        [HttpGet("{id}")]
//        [AllowAnonymous]
//        public virtual async Task<ActionResult<SampleDTO>> GetById(int id)
//        {
//            var dto = await _samplesService.GetEntityByIdAsync(id);
//            if (dto == null)
//            {
//                return NotFound();
//            }

//            return Ok(dto);
//        }

//        /// <summary>
//        /// Add new Sample
//        /// </summary>
//        /// <param name="request">Sample create request</param>
//        /// <returns>
//        /// Dto of Sample
//        /// </returns>
//        /// <response code="500">Internal error on server</response>
//        /// <response code="404">Sample not found</response>
//        /// <response code="403">You don`t have permission to create Sample</response>
//        /// <response code="400">Model is not valid</response>
//        /// <response code="200">Success</response>
//        [HttpPost]
//        public virtual async Task<ActionResult<SampleDTO>> Create([FromBody] SampleRequest request)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var dto = await _samplesService.CreateEntityAsync(request);
//            if (dto == null)
//            {
//                return StatusCode(500);
//            }

//            return CreatedAtAction("GetById", new { id = dto.Id }, dto);
//        }

//        /// <summary>
//        /// Update Sample
//        /// </summary>
//        /// <param name="id">Sample identifier</param>
//        /// <param name="request">Sample update request</param>
//        /// <returns>
//        /// Action Result
//        /// </returns>
//        /// <response code="500">Internal error on server</response>
//        /// <response code="404">Sample not found</response>
//        /// <response code="403">You don`t have permission to update Sample</response>
//        /// <response code="400">Model is not valid</response>
//        /// <response code="200">Success</response>
//        [HttpPut("{id}")]
//        public virtual async Task<ActionResult> Update([FromRoute] int id, [FromBody] SampleRequest request)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var result = await _samplesService.UpdateEntityByIdAsync(request, id);
//            if (!result)
//            {
//                return StatusCode(500);
//            }

//            return NoContent();
//        }

//        /// <summary>
//        /// Delete Sample
//        /// </summary>
//        /// <param name="id">Sample identifier</param>
//        /// <returns>
//        /// Action Result
//        /// </returns>
//        /// <response code="500">Internal error on server</response>
//        /// <response code="404">Sample not found</response>
//        /// <response code="403">You don`t have permission to delete Sample</response>
//        /// <response code="400">Model is not valid</response>
//        /// <response code="200">Success</response>
//        [HttpDelete("{id}")]
//        public virtual async Task<ActionResult> Delete(int id)
//        {
//            var result = await _samplesService.DeleteEntityByIdAsync(id);
//            if (!result)
//            {
//                return StatusCode(500);
//            }

//            return NoContent();
//        }
//    }
//}
