using BlazorChat.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat.Server
{
    public class SignalRHub : Hub
    {
        public async Task SendMessageAsync(ChatMessage message, string userName)
        {
            await Clients.All.SendAsync("ReceiveMessage", message, userName);
        }
        public async Task ChatNotificationAsync(string message, string receiverUserId, string senderUserId)
        {
            await Clients.All.SendAsync("ReceiveChatNotification", message, receiverUserId, senderUserId);
        }

        public async Task DeleteMessage(ChatMessage message) 
        {
            await Clients.All.SendAsync("DeleteMessage", message);
        }

        public async Task EditMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("EditMessage", message);
        }
    }
}
