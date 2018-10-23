using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Hubs;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private IInvitationsService _invitationsService;
        private IHubContext<InvitationHub> _hubContext;

        public InvitationsController(IInvitationsService invitationsService, IHubContext<InvitationHub> hubContext)
        {
            _hubContext = hubContext;
            _invitationsService = invitationsService;
        }

        // GET: /invitations
        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<InvitationDTO>>> Get()
        {
            var dtos = await _invitationsService.GetAllInvitationsAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<InvitationDTO>> GetById(int id)
        {
            var dto = await _invitationsService.GetInvitationByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: /invitations
        //[Authorize(Roles = "recruiter, admin")]
        [AllowAnonymous]
        [HttpPost]
        //public virtual async Task<ActionResult<InvitationDTO>> Create([FromBody] InvitationRequest request)
        public virtual async Task<ActionResult<InvitationRequest>> Create([FromBody] InvitationRequest request)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var aaa = _hubContext.Clients.User(request.EmployeeId);
            var bbb = _hubContext.Clients.All;



            await _hubContext.Clients.User(request.EmployeeId).SendAsync("receiveInvitation", request.Message);

            return request;
            //var dtos = await _invitationsService.CreateInvitationAsync(request);
            //if (dtos == null)
            //{
            //    return StatusCode(500);
            //}

            //return CreatedAtAction("GetById", new { id = dtos.Id }, dtos);
        }

        // PUT: /invitations/:id
        [Authorize(Roles = "recruiter, admin")]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute]int id, [FromBody]InvitationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invitationsService.UpdateInvitationByIdAsync(request, id);
            if (!result)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // DELETE: /invitations/:id
        [Authorize(Roles = "recruiter, admin")]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await _invitationsService.DeleteInvitationByIdAsync(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

    }
}