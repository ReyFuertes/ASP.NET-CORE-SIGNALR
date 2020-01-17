using ApiProj.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProj.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string name, string msg)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Message = msg,
                SentAt = DateTimeOffset.UtcNow
            };
            await Clients.All.SendAsync("Notification", message.SenderName, message.SentAt, message.Message);

        }
    }
}
