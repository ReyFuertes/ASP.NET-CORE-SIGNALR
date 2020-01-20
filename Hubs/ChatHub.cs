using Api.Models;
using ApiProj.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ApiProj.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string name, string msg, string guid = null)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Message = msg,
                SentAt = DateTimeOffset.UtcNow
            };
            await Clients.All.SendAsync("Notification", message.SenderName, message.SentAt, message.Guid, message.Message);

        }
    }
}
