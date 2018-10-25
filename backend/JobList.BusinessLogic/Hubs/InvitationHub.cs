using JobList.BusinessLogic.Interfaces;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Hubs
{
    public class InvitationHub : Hub
    {
        private readonly IInvitationsService _invitationsService;

        public InvitationHub(IInvitationsService invitationsService)
        {
            _invitationsService = invitationsService;
        }

        [Authorize]
        public async Task SendInvitation(InvitationRequest request)
        {
            var result = await _invitationsService.CreateInvitationAsync(request);
        }

        [Authorize]
        public async Task DeleteInvitation(int id)
        {
            var result = await _invitationsService.DeleteInvitationByIdAsync(id);
        }

        [AllowAnonymous]
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        [AllowAnonymous]
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
