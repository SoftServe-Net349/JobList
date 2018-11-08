using JobList.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IHubContext<AdminHub> _adminHub;

        public ChatHub(IChatRoomService chatRoomService, IHubContext<AdminHub> adminHub)
        {
            _chatRoomService = chatRoomService;
            _adminHub = adminHub;
        }

        public override async Task OnConnectedAsync()
        {
            if(Context.User.Identity.IsAuthenticated)
            {
                await base.OnConnectedAsync();
                return;
            }

            var roomId = await _chatRoomService.CreateRoom(Context.ConnectionId);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());

            await Clients.Caller.SendAsync("ReceiveMessage", "JobList Admin", DateTimeOffset.UtcNow, "Hello! What can we help you with today?");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string name, string text)
        {
            var roomId = await _chatRoomService.GetRoomForConnectionId(Context.ConnectionId);

            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.UtcNow
            };

            await _chatRoomService.AddMessage(roomId, message);

            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", message.SenderName, message.SendAt, message.Text);
        }

        public async Task SetName(string visitorName)
        {
            var roomName = $"Chat with {visitorName} from the web";

            var roomId = await _chatRoomService.GetRoomForConnectionId(Context.ConnectionId);

            await _chatRoomService.SetRoomName(roomId, roomName);

            await _adminHub.Clients.All.SendAsync("ActiveRooms", await _chatRoomService.GetAllRooms());
        }

        //[Authorize]
        public async Task JoinRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
                throw new ArgumentException("Invalid room ID");

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        //[Authorize]
        public async Task LeaveRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
                throw new ArgumentException("Invalid room ID");

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }

    public class ChatMessage
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset SendAt { get; set; }
    }
}
