using JobList.BusinessLogic.Interfaces;
using JobList.Common.ChatHelpers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Hubs
{
    public class AdminHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IHubContext<ChatHub> _chatHub;

        public AdminHub(IChatRoomService chatRoomService, IHubContext<ChatHub> chatHub)
        {
            _chatRoomService = chatRoomService;
            _chatHub = chatHub;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ActiveRooms", await _chatRoomService.GetAllRooms());

            await base.OnConnectedAsync();
        }

        public async Task SendAgentMessage(Guid roomId, string text)
        {
            var message = new ChatMessage
            {
                SenderName = "JobList Admin",
                Text = text,
                SendAt = DateTimeOffset.UtcNow
            };

            await _chatRoomService.AddMessage(roomId, message);

            await _chatHub.Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", message.SenderName, message.SendAt, message.Text);
        }

        public async Task LoadHistory(Guid roomId)
        {
            var history = await _chatRoomService.GetMessageHistory(roomId);

            await Clients.Caller.SendAsync("ReceiveMessages", history);
        }
    }
}
