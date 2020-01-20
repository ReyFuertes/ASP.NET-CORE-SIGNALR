using Api.Services;
using ApiProj.Models;
using ApiProj.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProj.Repository
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly DataContext _context;

        public ChatMessageRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ChatMessage>> GetMessages()
        {
            return  _context.ChatMessages.ToList();
        }

        public async Task<ChatMessage> SaveMessage(ChatMessage chatMessage)
        {
            await _context.ChatMessages.AddAsync(chatMessage);
            await _context.SaveChangesAsync();

            return chatMessage;
        }
    }
}
