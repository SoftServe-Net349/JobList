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
            this._invitationsService = invitationsService;
        }


        public async Task SendInvitation(string employeeId, string message)
        {
           await Clients.User(employeeId).SendAsync("receiveInvitation", message);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
        //public async Task SendInvitation(string employeeId, InvitationRequest request)
        //{
        //    Clients.User(employeeId).invitation(request);
        //}

    }
}
