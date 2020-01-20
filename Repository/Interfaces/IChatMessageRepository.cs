using Api.Models;
using ApiProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProj.Repository.Interfaces
{
    public interface IChatMessageRepository
    {
        Task<ChatMessage> SaveMessage(ChatMessage chatMessage);
        Task<IEnumerable<ChatMessage>> GetMessages();
    }
}
