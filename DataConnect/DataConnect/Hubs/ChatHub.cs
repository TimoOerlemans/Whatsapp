using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataConnect.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddToGroup(string groupName, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("EnteredOrLeft",
                $"{user} has" +
                $" joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName, string user)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("EnteredOrLeft",
                $"{user} has" +
                $" left the group {groupName}.");
        }

        public async Task SendMessageGroup(string groupName, string user, string message)
        {
            if (message.Length > 100) return;
            await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
        }

        public async Task TypingGroup(string groupName, string user)
        {
            await Clients.Group(groupName).SendAsync("TypingMessage", user);
        }


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task Typing(string user)
        {
            await Clients.All.SendAsync("TypingMessage", user);
        }
    }
}